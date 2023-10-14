using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.SpaceMovement;
using Itmo.ObjectOrientedProgramming.Lab1.Models.SpaceTravelResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Obstacles;

public interface IObstacle
{
    public SpaceTravelResult DealDamageAndGetShipCondition(ISpaceShuttle shuttle);
}