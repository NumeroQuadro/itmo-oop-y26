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

        if (shuttle.Deflector is null)
        {
            return new ShuttleIsDestroyed();
        }

        if (shuttle.Deflector.HitPoints < Constants.SpaceWhaleDamage)
        {
            return new ShuttleIsDestroyed();
        }

        if (shuttle.Deflector.HitPoints <= 0)
        {
            return new ShuttleIsDestroyed();
        }

        return shuttle.TakeDamageAndGetResult(Constants.SpaceWhaleDamage);
    }
}