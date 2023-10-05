using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.EnvironmentTypes;

public interface IEnvironment
{
    public uint Length { get; }
    public IEnumerable<IObstacle> GetObstacles();
}