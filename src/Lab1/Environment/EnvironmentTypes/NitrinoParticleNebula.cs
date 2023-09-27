using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.EnvironmentTypes;

public class NitrinoParticleNebula
{
    private List<INitrinoParticleNebulaObstacle> _obstacles;

    public NitrinoParticleNebula()
    {
        _obstacles = new List<INitrinoParticleNebulaObstacle>();
    }

    public NitrinoParticleNebula(IEnumerable<INitrinoParticleNebulaObstacle> obstacles)
    {
        _obstacles = obstacles.ToList();
    }

    public void AddSpaceWhale(INitrinoParticleNebulaObstacle spaceWhale)
    {
        _obstacles.Add(spaceWhale);
    }

    public IEnumerable<INitrinoParticleNebulaObstacle> GetObstacles()
    {
        return _obstacles.AsEnumerable();
    }
}