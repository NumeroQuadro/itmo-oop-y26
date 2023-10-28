using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.SpaceMovement;
using Itmo.ObjectOrientedProgramming.Lab1.Models.SpaceTravelResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.EnvironmentTypes;

public class NitrinoParticleNebula : IEnvironment
{
    private readonly List<SpaceWhale> _obstacles;

    public NitrinoParticleNebula(IEnumerable<SpaceWhale> obstaclesCollection)
    {
        _obstacles = obstaclesCollection.ToList();
    }

    public SpaceTravelResult TakeOverTheShip(ISpaceShuttle shuttle)
    {
        return GetShuttleThroughAllObstacles(shuttle);
    }

    private SpaceTravelResult GetShuttleThroughAllObstacles(ISpaceShuttle shuttle)
    {
        IEnumerable<SpaceTravelResult> results = _obstacles.Select(x => x.DealDamageAndGetShipCondition(shuttle));
        var comparator = new ResultsComparator(results);

        return comparator.CompareResultsAndGetSummarize();
    }
}