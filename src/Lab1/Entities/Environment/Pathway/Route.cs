using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.SpaceMovement;
using Itmo.ObjectOrientedProgramming.Lab1.Models.SpaceTravelResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Pathway;

public class Route
{
    private readonly IEnumerable<Segment> _segments;

    public Route(IEnumerable<Segment> segments)
    {
        _segments = segments;
    }

    public SpaceTravelResult Travel(ISpaceShuttle? shuttle)
    {
        if (shuttle is null)
        {
            throw new ArgumentException("shuttle is null! cannot complete route!");
        }

        IEnumerable<SpaceTravelResult> results = _segments
            .Select(x => x.TakeOverTheShip(shuttle));
        var comparator = new ResultsComparator(results);

        return comparator.CompareResultsAndGetSummarize();
    }
}