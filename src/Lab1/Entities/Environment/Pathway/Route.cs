using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.EnvironmentTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.SpaceMovement;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.SpaceTravelResults;
using Itmo.ObjectOrientedProgramming.Lab1.Services.ResultsHandler;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Pathway;

public class Route
{
    private readonly IEnumerable<Segment> _segments;
    private readonly FuelMarket _market;

    public Route(IEnumerable<Segment> segments)
    {
        _market = new FuelMarket();
        _segments = segments;
    }

    public TripResultInformation Travel(ISpaceShuttle? shuttle)
    {
        if (shuttle is null)
        {
            throw new ArgumentException("shuttle is null! cannot complete route!");
        }

        double traveledTime = _segments.Sum(x => x.GetTime(shuttle));

        IEnumerable<SpaceTravelResult> results = _segments
            .Select(x => x.TakeOverTheShip(shuttle));
        var comparator = new ResultsComparator(results);

        SpaceTravelResult summarizeResult = comparator.CompareResultsAndGetSummarize();

        if (summarizeResult is SpaceTravelResult.Success)
        {
            TrackStocksForTravel(shuttle);
        }

        return new TripResultInformation(shuttle, summarizeResult, _market.GetCost, traveledTime);
    }

    private void TrackStocksForTravel(ISpaceShuttle shuttle)
    {
        foreach (Segment segment in _segments)
        {
            if (segment.Environment is Space or NitrinoParticleNebula)
            {
                segment.IncreaseWastedAmountOfActivePlasma(shuttle, segment.Length);
            }
            else if (segment.Environment is NebulaInHighDensitySpace)
            {
                segment.IncreaseWastedAmountOfGravitonFuel(shuttle, segment.Length);
            }

            segment.SetWastedAmountOfActivePlasma(_market);
            segment.SetWastedAmountOfGravitonFuel(_market);
        }
    }
}