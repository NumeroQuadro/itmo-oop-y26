using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.SpaceMovement;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.ResultsHandler;

public class ResultsHandler : IResultsComparator
{
    private readonly IEnumerable<TripResultInformation> _results;

    public ResultsHandler(IEnumerable<TripResultInformation> results)
    {
        _results = results;
    }

    public ISpaceShuttle GetShipWithBestResult()
    {
        IEnumerable<TripResultInformation> sorted = _results
            .OrderBy(x => x.Cost)
            .ThenBy(x => x.TraveledTime);

        return sorted.First().Shuttle;
    }
}