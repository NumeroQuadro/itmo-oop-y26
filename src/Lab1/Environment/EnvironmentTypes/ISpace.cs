using Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.EnvironmentTypes;

public interface ISpace : IEnvironment
{
    public void AddAsteroid(ISpaceObstacle asteroid);
    public void AddMeteor(ISpaceObstacle meteor);
}