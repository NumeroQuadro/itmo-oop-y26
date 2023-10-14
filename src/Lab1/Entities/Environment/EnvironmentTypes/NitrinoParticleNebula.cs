using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.Engine.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.SpaceMovement;
using Itmo.ObjectOrientedProgramming.Lab1.Models.SpaceTravelResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.EnvironmentTypes;

public class NitrinoParticleNebula : IEnvironment
{
    private int _length;
    private List<SpaceWhale> _obstacles;

    public NitrinoParticleNebula(IEnumerable<SpaceWhale> obstaclesCollection, int length)
    {
        _obstacles = obstaclesCollection.ToList();
        _length = length;
    }

    public void AddSpaceWhales(int numberOfSpaceWhales)
    {
        for (uint i = 0; i < numberOfSpaceWhales; ++i)
        {
            _obstacles.Add(new SpaceWhale());
        }
    }

    public SpaceTravelResult TakeOverTheShip(ISpaceShuttle shuttle)
    {
        if (IsShuttlePossibleToStayInCurrentEnvironment(shuttle))
        {
            return GetShuttleThroughAllObstacles(shuttle);
        }

        return new ImpossibleToGoToEnvironment();
    }

    private bool IsShuttlePossibleToStayInCurrentEnvironment(ISpaceShuttle shuttle)
    {
        if (shuttle.ImpulseEngine is not EClassImpulseEngine || _length > shuttle.ImpulseEngine.MaxLength)
        {
            return false;
        }

        return true;
    }

    private SpaceTravelResult GetShuttleThroughAllObstacles(ISpaceShuttle shuttle)
    {
        IEnumerable<SpaceTravelResult> results = _obstacles.Select(x => x.DealDamageAndGetShipCondition(shuttle));
        var comparator = new ResultsComparator(results);

        return comparator.CompareResultsAndGetSummarize();
    }
}