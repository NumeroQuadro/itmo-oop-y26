using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.SpaceMovement;
using Itmo.ObjectOrientedProgramming.Lab1.Models.SpaceTravelResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.EnvironmentTypes;

public class Space : IEnvironment
{
    private readonly IEnumerable<ISpaceObstacle> _obstacles;

    public Space(IEnumerable<ISpaceObstacle> obstacles)
    {
        _obstacles = obstacles.ToList();
    }

    public SpaceTravelResult TakeOverTheShip(ISpaceShuttle shuttle)
    {
        return GetShuttleThroughAllObstacles(shuttle);
    }

    private SpaceTravelResult GetShuttleThroughAllObstacles(ISpaceShuttle shuttle)
    {
        IEnumerable<SpaceTravelResult> resultsAsteroids = _obstacles.Select(x => x.DealDamageAndGetShipCondition(shuttle));
        IEnumerable<SpaceTravelResult> results = resultsAsteroids.Concat(_obstacles.Select(x => x.DealDamageAndGetShipCondition(shuttle)));
        var comparator = new ResultsComparator(results);

        return comparator.CompareResultsAndGetSummarize();
    }
}