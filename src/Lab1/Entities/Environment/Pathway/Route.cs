using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Pathway;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.ResultsHandler;
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

    public TripResultInformation? GoThroughAllSegmentsAndGetResultOfTrip(ISpaceShuttle? shuttle)
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
            TripResultInformation? result = segment.GoThroughAllEnvironmentsAndGetResultOfTrip(shuttle);

            if (result.TravelResult is Success successResult)
            {
                traveledTime += result.TraveledTime;
                wastedActivePlasmaFuel += result.BurnedActivePlasmaFuel;
                wastedGravitonFuel += result.BurnedGravitonFuel;
            }
            else
            {
                return new TripResultInformation(result.TravelResult, wastedActivePlasmaFuel, wastedGravitonFuel, traveledTime);
            }
        }

        return new TripResultInformation(new Success(), wastedActivePlasmaFuel, wastedGravitonFuel, traveledTime);
    }
}