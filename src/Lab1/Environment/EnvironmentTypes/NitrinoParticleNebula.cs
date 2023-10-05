using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.EnvironmentTypes;

public class NitrinoParticleNebula : IEnvironment
{
    private List<IObstacle> _obstacles;

    public NitrinoParticleNebula(uint numberOfSpaceWhales, uint length)
    {
        _obstacles = new List<IObstacle>();
        AddSpaceWhales(numberOfSpaceWhales);
        Length = length;
    }

    public uint Length { get; init; }

    public void AddSpaceWhales(uint numberOfSpaceWhales)
    {
        for (uint i = 0; i < numberOfSpaceWhales; ++i)
        {
            _obstacles.Add(new SpaceWhale());
        }
    }

    public IEnumerable<IObstacle> GetObstacles()
    {
        return _obstacles.AsEnumerable();
    }
}