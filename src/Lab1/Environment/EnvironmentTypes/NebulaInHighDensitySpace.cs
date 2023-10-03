using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.EnvironmentTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment;

public class NebulaInHighDensitySpace : IEnvironment
{
    private List<IObstacle> _obstacles;

    public NebulaInHighDensitySpace(uint numberOfDustingOfAntiMatters)
    {
        _obstacles = new List<IObstacle>();
        AddDustingOfAntiMatters(numberOfDustingOfAntiMatters);
    }

    public void AddDustingOfAntiMatters(uint numberOfDustingOfAntiMatters)
    {
        for (uint i = 0; i < numberOfDustingOfAntiMatters; ++i)
        {
            _obstacles.Add(new DustingOfAntiMatter());
        }
    }

    public IEnumerable<IObstacle> GetObstacles()
    {
        return _obstacles.AsEnumerable();
    }
}