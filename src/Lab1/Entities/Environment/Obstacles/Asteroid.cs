using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.ProtectionState;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement.SpaceTravelResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;

public class Asteroid : ISpaceObstacle
{
    public SpaceTravelResult DealDamageAndGetShipCondition(ISpaceShuttle shuttle)
    {
        if (shuttle.Deflector is not null)
        {
            ProtectionState resultAfterDeflectorDamaged = shuttle.Deflector.TakeDamage(Constants.AsteroidDamage);
            if (resultAfterDeflectorDamaged is ImpossibleToBeDamaged)
            {
                if (shuttle.ShipHull.TakeDamage(Constants.AsteroidDamage) is ImpossibleToBeDamaged)
                {
                    return new ShuttleIsDestroyed();
                }
            }
        }

        if (shuttle.ShipHull.TakeDamage(Constants.AsteroidDamage) is ImpossibleToBeDamaged)
        {
            return new ShuttleIsDestroyed();
        }

        return new Success();
    }
}