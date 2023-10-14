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
        IEnumerable<SpaceTravelResult> notSuccessResults = _results
            .Select(x => x)
            .Where(x => x is not SpaceTravelResult.Success);

        SpaceTravelResult? summarizeResult = notSuccessResults.FirstOrDefault();
        if (summarizeResult is null)
        {
            return new SpaceTravelResult.Success();
        }

        return summarizeResult;
    }
}