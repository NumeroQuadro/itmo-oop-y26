using Itmo.ObjectOrientedProgramming.Lab1.Environment.EnvironmentTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;

public interface IObstacle
{
    private bool IsObstacleAndShipInSameEnvironment(ISpaceShuttle shuttle)
    {
        return shuttle.CurrentEnvironment == CurrentEnvironment;
    }
    public IEnvironment CurrentEnvironment { get; init; }
}