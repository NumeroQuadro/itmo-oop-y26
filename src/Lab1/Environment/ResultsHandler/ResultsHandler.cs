using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.EnvironmentTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.ResultsHandler;

public class ResultsHandler
{
    private readonly Dictionary<TripResultInformation, ISpaceShuttle> _comprasionValues = new Dictionary<TripResultInformation, ISpaceShuttle>();

    public void AddValue(TripResultInformation result, ISpaceShuttle shuttle)
    {
        _comprasionValues.Add(result, shuttle);
    }

    public ISpaceShuttle? GetShuttleWhichIsMoreProfit(IEnvironment environment)
    {
        if (environment is Space)
        {
            return FindBestShuttleInSpace();
        }

        if (environment is NebulaInHighDensitySpace)
        {
            return FindBestShuttleInHighDensitySpace();
        }

        return null;
    }

    private ISpaceShuttle FindBestShuttleInSpace()
    {
        var orderedDictionary = _comprasionValues
            .OrderBy(x => x.Key.TraveledTime)
            .ToDictionary(x => x.Key, x => x.Value);

        return orderedDictionary.First().Value;
    }

    private ISpaceShuttle FindBestShuttleInHighDensitySpace()
    {
        var orderedDictionary = _comprasionValues
            .OrderBy(x => x.Value.JumpEngine?.MaxLength)
            .ToDictionary(x => x.Key, x => x.Value);

        return orderedDictionary.Last().Value;
    }
}