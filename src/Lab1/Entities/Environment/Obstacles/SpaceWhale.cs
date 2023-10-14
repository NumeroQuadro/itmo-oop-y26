using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.SpaceMovement;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.SpaceTravelResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Obstacles;

public class SpaceWhale : INitrinoParticleNebulaObstacle
{
    private const double SpaceWhaleDamage = 150.0;
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

        if (shuttle.Deflector.TakeDamageAndGetResult(SpaceWhaleDamage) is ProtectionState.ImpossibleToBeDamaged)
        {
            return new SpaceTravelResult.ShuttleIsDestroyed();
        }

        return new SpaceTravelResult.Success();
    }
}