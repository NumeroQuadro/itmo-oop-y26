using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.EnvironmentTypes;

public class Space : ISpace
{
    private List<IObstacle> _obstacles;

    public Space()
    {
        _obstacles = new List<IObstacle>();
    }

    public Space(IEnumerable<IObstacle> obstacles)
    {
        _obstacles = obstacles.ToList();
    }

    public void AddMeteor(ISpaceObstacle meteor)
    {
        _obstacles.Add(meteor);
    }

    public void AddAsteroid(ISpaceObstacle asteroid)
    {
        _obstacles.Add(asteroid);
    }

    public IEnumerable<IObstacle> GetObstacles()
    {
        return _obstacles.AsEnumerable();
    }
}