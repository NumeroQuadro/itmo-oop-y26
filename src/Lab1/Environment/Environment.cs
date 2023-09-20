using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment;

public class Environment
{
    private readonly EnvironmentType _environmentType;
    private readonly List<Obstacle> _obstacles;
    private List<SpaceShuttle> _spaceShuttles;

    public Environment(EnvironmentType environmentType, IEnumerable<Obstacle> obstacles)
    {
        _environmentType = environmentType;
        _obstacles = obstacles.ToList();
        _spaceShuttles = new List<SpaceShuttle>();
    }

    public void AddShip(SpaceShuttle shuttle)
    {
        _spaceShuttles.Add(shuttle);
    }
}