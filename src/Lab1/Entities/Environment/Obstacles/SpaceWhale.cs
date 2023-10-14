using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.SpaceMovement;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.SpaceTravelResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Obstacles;

public class SpaceWhale : INitrinoParticleNebulaObstacle
{
    public SpaceTravelResult DealDamageAndGetShipCondition(ISpaceShuttle shuttle)
    {
        if (shuttle.ShipHull.HasAntiNitrinoEmitter)
        {
            return new SpaceTravelResult.Success();
        }

        if (shuttle.Deflector is null)
        {
            return new SpaceTravelResult.ShuttleIsDestroyed();
        }

        return shuttle.TakeDamageAndGetResult(Constants.SpaceWhaleDamage);
    }
}