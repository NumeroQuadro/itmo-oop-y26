using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;

public class Asteroid : ISpaceObstacle
{
    public SpaceTravelResult? DealDamageAndGetShipCondition(ISpaceShuttle shuttle)
    {
        SpaceTravelResult? shuttleConditionAfterDamaged = shuttle.TakeDamageAndGetResult(Constants.AsteroidDamage);
        if (shuttleConditionAfterDamaged != null)
        {
            return shuttleConditionAfterDamaged;
        }

        return null;
    }
}