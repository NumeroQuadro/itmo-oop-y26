using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.SpaceMovement;
using Itmo.ObjectOrientedProgramming.Lab1.Models.SpaceTravelResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Obstacles;

public class Meteor : ISpaceObstacle
{
    private const double MeteorDamage = 10.0;
    public SpaceTravelResult DealDamageAndGetShipCondition(ISpaceShuttle shuttle)
    {
        return shuttle.TakeDamageAndGetResult(MeteorDamage);
    }
}