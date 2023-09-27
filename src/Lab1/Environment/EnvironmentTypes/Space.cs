using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment;

public class Space
{
    private List<ISpaceObstacle> _obstacles;

    public Space()
    {
        _obstacles = new List<ISpaceObstacle>();
    }

    public Space(IEnumerable<ISpaceObstacle> obstacles)
    {
        _obstacles = obstacles.ToList();
    }

    public void AddAsteroid(Asteroid asteroid)
    {
        _obstacles.Add(asteroid);
    }

    public void AddMeteor(ISpaceObstacle meteor)
    {
        _obstacles.Add(meteor);
    }

    public IEnumerable<ISpaceObstacle> GetObstacles()
    {
        return _obstacles.AsEnumerable();
    }
}