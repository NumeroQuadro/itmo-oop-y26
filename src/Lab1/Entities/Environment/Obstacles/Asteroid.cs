using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.SpaceMovement;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.SpaceTravelResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Obstacles;

public class Asteroid : ISpaceObstacle
{
    public SpaceTravelResult DealDamageAndGetShipCondition(ISpaceShuttle shuttle)
    {
        return shuttle.TakeDamageAndGetResult(Constants.AsteroidDamage);
    }
}