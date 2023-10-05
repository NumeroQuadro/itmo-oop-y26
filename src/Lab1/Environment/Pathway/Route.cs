using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement.SpaceTravelResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Pathway;

public class Route
{
    private readonly IReadOnlyCollection<PathSegment> _segments;

    public Route(IReadOnlyCollection<PathSegment> segments)
    {
        _segments = segments;
    }

    public SpaceTravelResult? GoThroughAllSegmentsAndGetResultOfTrip(ISpaceShuttle? shuttle)
    {
        if (shuttle is null)
        {
            return null;
        }

        double traveledTime = 0;
        double wastedActivePlasmaFuel = 0;
        double wastedGravitonFuel = 0;

        foreach (PathSegment segment in _segments)
        {
            SpaceTravelResult? result = segment.GoThroughAllEnvironmentsAndGetResultOfTrip(shuttle);

            if (result is Success successResult)
            {
                traveledTime += successResult.TraveledTime;
                wastedActivePlasmaFuel += successResult.BurnedActivePlasmaFuel;
                wastedGravitonFuel += successResult.BurnedGravitonFuel;
            }
            else
            {
                return result;
            }
        }

        return new Success(wastedActivePlasmaFuel, wastedGravitonFuel, traveledTime);
    }
}