using Itmo.ObjectOrientedProgramming.Lab1.Environment.EnvironmentTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;

public interface IObstacle
{
    public IEnvironment CurrentEnvironment { get; init; }
}