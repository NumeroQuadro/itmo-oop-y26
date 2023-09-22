using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment;

public class Space : IEnvironment
{
    private List<ObstacleType> _obstacles;

    public Space(IEnumerable<ObstacleType> obstacles)
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

    public IEnumerable<ObstacleType> GetObstacles()
    {
        return _obstacles.AsEnumerable();
    }
}