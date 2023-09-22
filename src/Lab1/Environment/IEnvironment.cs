using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment;

public interface IEnvironment
{
    public IEnumerable<ObstacleType> GetObstacles();
}