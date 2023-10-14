using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.SpaceMovement;
using Itmo.ObjectOrientedProgramming.Lab1.Models.SpaceTravelResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.EnvironmentTypes;

public class Space
{
    private List<Asteroid> _asteroids;
    private List<Meteor> _meteors;

    public Space(IEnumerable<Asteroid> asteroids, IEnumerable<Meteor> meteors, int length)
    {
        _asteroids = asteroids.ToList();
        _meteors = meteors.ToList();
        Length = length;
    }

    public int Length { get; }

    public bool IsShuttlePossibleToStayInCurrentEnvironment(ISpaceShuttle shuttle)
    {
        if (shuttle.ImpulseEngine is null || Length > shuttle.ImpulseEngine.MaxLength)
        {
            return false;
        }

        return true;
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
        IEnumerable<SpaceTravelResult> resultsAsteroids = _asteroids.Select(x => x.DealDamageAndGetShipCondition(shuttle));
        IEnumerable<SpaceTravelResult> results = resultsAsteroids.Concat(_meteors.Select(x => x.DealDamageAndGetShipCondition(shuttle)));
        var comparator = new ResultsComparator(results);

        return comparator.CompareResultsAndGetSummarize();
    }
}