using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;

public class SpaceWhale : INitrinoParticleNebulaObstacle
{
    public SpaceTravelResult? DealDamageAndGetShipCondition(ISpaceShuttle shuttle)
    {
        if (shuttle.ShipHull.HasAntiNitrinoEmitter)
        {
            return null;
        }

        return shuttle.TakeDamageAndGetResult(Constants.SpaceWhaleDamage);
    }
}