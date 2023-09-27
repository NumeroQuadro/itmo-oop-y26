using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment;

public class NebulaInHighDensitySpace
{
    private List<INebulaInHighDensitySpaceObstacle> _obstacles;

    public NebulaInHighDensitySpace()
    {
        _obstacles = new List<INebulaInHighDensitySpaceObstacle>();
    }

    public NebulaInHighDensitySpace(IEnumerable<INebulaInHighDensitySpaceObstacle> obstacles)
    {
        _obstacles = obstacles.ToList();
    }

    public void AddDustingOfAntiMatter(DustingOfAntiMatter dustingOfAntiMatter)
    {
        _obstacles.Add(dustingOfAntiMatter);
    }

    public IEnumerable<INebulaInHighDensitySpaceObstacle> GetObstacles()
    {
        return _obstacles.AsEnumerable();
    }
}