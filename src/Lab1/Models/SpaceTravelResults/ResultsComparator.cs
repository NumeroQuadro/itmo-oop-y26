using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.SpaceTravelResults;

public class ResultsComparator
{
    private readonly List<SpaceTravelResult> _results;

    public ResultsComparator(IEnumerable<SpaceTravelResult> results)
    {
        _results = results.ToList();
    }

    public SpaceTravelResult CompareResultsAndGetSummarize()
    {
        if (_results.Contains(new CrewDeath()))
        {
            return new CrewDeath();
        }

        if (_results.Contains(new ShuttleIsDestroyed()))
        {
            return new ShuttleIsDestroyed();
        }

        if (_results.Contains(new ImpossibleToGoToEnvironment()))
        {
            return new ImpossibleToGoToEnvironment();
        }

        if (_results.Contains(new ShuttleLost()))
        {
            return new ShuttleLost();
        }

        return new Success();
    }
}