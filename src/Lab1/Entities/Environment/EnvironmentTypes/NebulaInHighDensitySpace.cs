using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.EnvironmentTypes;

public class NebulaInHighDensitySpace : IEnvironment
{
    private List<IObstacle> _obstacles;

    public NebulaInHighDensitySpace(uint numberOfDustingOfAntiMatters, uint length)
    {
        _obstacles = new List<IObstacle>();
        AddDustingOfAntiMatters(numberOfDustingOfAntiMatters);
        Length = length;
    }

    public uint Length { get; init; }

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