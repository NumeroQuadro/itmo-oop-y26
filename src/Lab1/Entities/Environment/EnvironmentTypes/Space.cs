using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.SpaceMovement;
using Itmo.ObjectOrientedProgramming.Lab1.Models.SpaceTravelResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.EnvironmentTypes;

public class Space : IEnvironment
{
    private List<Asteroid> _asteroids;
    private List<Meteor> _meteors;

    public Space(IEnumerable<Asteroid> asteroids, IEnumerable<Meteor> meteors)
    {
        _asteroids = asteroids.ToList();
        _meteors = meteors.ToList();
    }

    public SpaceTravelResult TakeOverTheShip(ISpaceShuttle shuttle)
    {
        return GetShuttleThroughAllObstacles(shuttle);
    }

    private SpaceTravelResult GetShuttleThroughAllObstacles(ISpaceShuttle shuttle)
    {
        IEnumerable<SpaceTravelResult> resultsAsteroids = _asteroids.Select(x => x.DealDamageAndGetShipCondition(shuttle));
        IEnumerable<SpaceTravelResult> results = resultsAsteroids.Concat(_meteors.Select(x => x.DealDamageAndGetShipCondition(shuttle)));
        var comparator = new ResultsComparator(results);

        return comparator.CompareResultsAndGetSummarize();
    }
}