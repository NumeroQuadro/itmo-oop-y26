using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment;

public class NitrinoParticleNebula : IEnvironment
{
    private List<ObstacleType> _obstacles;

    public NitrinoParticleNebula()
    {
        _obstacles = new List<ObstacleType>();
    }

    public NitrinoParticleNebula(IEnumerable<ObstacleType> obstacles)
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

    public void AddSpaceWhale(SpaceWhale spaceWhale)
    {
        _obstacles.Add(spaceWhale);
    }

    public IEnumerable<ObstacleType> GetObstacles()
    {
        return _obstacles.AsEnumerable();
    }
}