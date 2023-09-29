using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.EnvironmentTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment;

public class NebulaInHighDensitySpace : IEnvironment
{
    private List<IObstacle> _obstacles;

    public NebulaInHighDensitySpace()
    {
        _obstacles = new List<IObstacle>();
    }

    public void AddDustringOfAntiMatter(INebulaInHighDensitySpaceObstacle obstacle)
    {
        _obstacles.Add(obstacle);
    }

    public IEnumerable<IObstacle> GetObstacles()
    {
        return _obstacles.AsEnumerable();
    }
}