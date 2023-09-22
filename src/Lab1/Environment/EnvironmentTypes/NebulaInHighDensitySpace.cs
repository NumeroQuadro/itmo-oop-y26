using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment;

public class NebulaInHighDensitySpace : IEnvironment
{
    private List<ObstacleType> _obstacles;

    public NebulaInHighDensitySpace()
    {
        _obstacles = new List<ObstacleType>();
    }

    public NebulaInHighDensitySpace(IEnumerable<ObstacleType> obstacles)
    {
        _obstacles = obstacles.ToList();
    }

    public void AddAsteroid(Asteroid asteroid)
    {
        _obstacles.Add(asteroid);
    }

    public void AddMeteor(Meteor meteor)
    {
        _obstacles.Add(meteor);
    }

    public void AddDustingOfAntiMatter(DustingOfAntiMatter dustingOfAntiMatter)
    {
        _obstacles.Add(dustingOfAntiMatter);
    }

    public IEnumerable<ObstacleType> GetObstacles()
    {
        return _obstacles.AsEnumerable();
    }
}