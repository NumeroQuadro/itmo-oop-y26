using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.EnvironmentTypes;

public class NitrinoParticleNebula : IEnvironment
{
    private List<IObstacle> _obstacles;

    public NitrinoParticleNebula()
    {
        _obstacles = new List<IObstacle>();
    }

    public NitrinoParticleNebula(IEnumerable<IObstacle> obstacles)
    {
        _obstacles = obstacles.ToList();
    }

    public void AddSpaceWhale(INitrinoParticleNebulaObstacle spaceWhale)
    {
        _obstacles.Add(spaceWhale);
    }

    public IEnumerable<IObstacle> GetObstacles()
    {
        return _obstacles.AsEnumerable();
    }
}