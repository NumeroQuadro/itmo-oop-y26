using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.EnvironmentTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;
using Itmo.ObjectOrientedProgramming.Lab1.Models.SpaceTravelResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.ResultsHandler;

public class ResultsHandler
{
    private readonly Dictionary<TripResultInformation, ISpaceShuttle> _comprasionValues = new Dictionary<TripResultInformation, ISpaceShuttle>();

    public void AddValue(TripResultInformation result, ISpaceShuttle shuttle)
    {
        if (result.TravelResult is Success)
        {
            _comprasionValues.Add(result, shuttle);
        }
    }

    public ISpaceShuttle GetShuttleWhichIsMoreProfit(IEnvironment environment)
    {
        if (environment is Space)
        {
            return FindBestPriceTrip();
        }

        if (environment is NebulaInHighDensitySpace)
        {
            return FindBestShuttleInHighDensitySpace();
        }

        return FindBestPriceTrip();
    }

    private ISpaceShuttle FindBestPriceTrip()
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