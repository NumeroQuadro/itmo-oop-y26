using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.ProtectionState;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement.SpaceTravelResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;

public class SpaceWhale : INitrinoParticleNebulaObstacle
{
    public SpaceTravelResult DealDamageAndGetShipCondition(ISpaceShuttle shuttle)
    {
        if (shuttle.ShipHull.HasAntiNitrinoEmitter)
        {
            return new Success();
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

        ProtectionState resultAfterDeflectorDamaged = shuttle.Deflector.TakeDamage(Constants.SpaceWhaleDamage);
        if (resultAfterDeflectorDamaged is ImpossibleToBeDamaged)
        {
            return new ShuttleIsDestroyed();
        }

        return new Success();
    }
}