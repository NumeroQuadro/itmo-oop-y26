using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Pathway;

public class Route
{
    private readonly IReadOnlyCollection<PathSegment> _segments;

    public Route(IReadOnlyCollection<PathSegment> segments)
    {
        _segments = segments;
    }

    public SpaceTravelResult? GoThroughAllSegmentsAndGetResultOfTrip(ISpaceShuttle shuttle)
    {
        foreach (PathSegment segment in _segments)
        {
            SpaceTravelResult? result = segment.GoThroughAllEnvironmentsAndGetResultOfTrip(shuttle);
            if (result != null)
            {
                return result;
            }
        }

        return null;
    }
}