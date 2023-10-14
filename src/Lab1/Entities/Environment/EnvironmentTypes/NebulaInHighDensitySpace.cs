using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.SpaceMovement;
using Itmo.ObjectOrientedProgramming.Lab1.Models.SpaceTravelResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.EnvironmentTypes;

public class NebulaInHighDensitySpace : IEnvironment
{
    private List<DustingOfAntiMatter> _obstacles;
    private int _length;

    public NebulaInHighDensitySpace(IEnumerable<DustingOfAntiMatter> obstaclesCollection, int length)
    {
        _obstacles = obstaclesCollection.ToList();
        _length = length;
    }

    public void AddDustingOfAntiMatters(int numberOfDustingOfAntiMatters)
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

    public SpaceTravelResult TakeOverTheShip(ISpaceShuttle shuttle)
    {
        if (IsShuttlePossibleToStayInCurrentEnvironment(shuttle))
        {
            return GetShuttleThroughAllObstacles(shuttle);
        }

        return new ImpossibleToGoToEnvironment();
    }

    private SpaceTravelResult GetShuttleThroughAllObstacles(ISpaceShuttle shuttle)
    {
        IEnumerable<SpaceTravelResult> results = _obstacles.Select(x => x.DealDamageAndGetShipCondition(shuttle));
        var comparator = new ResultsComparator(results);

        return comparator.CompareResultsAndGetSummarize();
    }

    private bool IsShuttlePossibleToStayInCurrentEnvironment(ISpaceShuttle shuttle)
    {
        if (shuttle.JumpEngine is null || _length > shuttle.JumpEngine.MaxLength)
        {
            return false;
        }

        return true;
    }
}