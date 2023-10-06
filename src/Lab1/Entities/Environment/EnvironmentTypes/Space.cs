using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.EnvironmentTypes;

public class Space : ISpace
{
    private List<IObstacle> _obstacles;

    public Space(uint numberOfAsteroids, uint numberOfMeteors, uint length)
    {
        _obstacles = new List<IObstacle>();
        AddAsteroids(numberOfAsteroids);
        AddMeteors(numberOfMeteors);
        Length = length;
    }

    public uint Length { get; init; }

    public void AddMeteors(uint numberOfMeteors)
    {
        for (uint i = 0; i < numberOfMeteors; ++i)
        {
            _obstacles.Add(new Meteor());
        }
    }

    public void AddAsteroids(uint numberOfAsteroids)
    {
        for (uint i = 0; i < numberOfAsteroids; ++i)
        {
            _obstacles.Add(new Asteroid());
        }
    }

    public IEnumerable<IObstacle> GetObstacles()
    {
        return _obstacles.AsEnumerable();
    }
}