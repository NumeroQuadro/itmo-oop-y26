using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Pathway;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.ResultsHandler;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement.SpaceTravelResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Pathway;

public class Route
{
    private readonly IEnumerable<PathSegment> _segments;

    public Route(IEnumerable<PathSegment> segments)
    {
        _segments = segments;
        ActivePlasmaFuel = new ActivePlasmaFuel();
        GravitonFuel = new GravitonFuel();
        ImpulseEngineWorkingTime = new ImpulseEngineWorkingTime();
        JumpEngineWorkingTime = new JumpEngineWorkingTime();
    }

    public ActivePlasmaFuel ActivePlasmaFuel { get; }
    public GravitonFuel GravitonFuel { get; }
    public ImpulseEngineWorkingTime ImpulseEngineWorkingTime { get; }
    public JumpEngineWorkingTime JumpEngineWorkingTime { get; }
    public TripResultInformation GoThroughAllSegmentsAndGetResultOfTrip(ISpaceShuttle? shuttle)
    {
        if (shuttle is null)
        {
            throw new ArgumentException("shuttle is null! cannot complete route!");
        }

        double totalDistance = 0;

        foreach (PathSegment segment in _segments)
        {
            SpaceTravelResult result = segment.GoThroughAllEnvironmentsAndGetResultOfTrip(shuttle);
            totalDistance += segment.CalculateEnvironmentsDistances();

            ActivePlasmaFuel.AddAmountOfMeasurableValue(segment.ActivePlasmaFuel.AmountOfMesuarableValue);
            GravitonFuel.AddAmountOfMeasurableValue(segment.GravitonFuel.AmountOfMesuarableValue);

            if (result is not Success)
            {
                return new TripResultInformation(result, ActivePlasmaFuel.Cost, GravitonFuel.Cost, 0);
            }
        }

        CountMeasurablesValuesAfterSpaceTravel(shuttle, totalDistance);
        double totalTime = ImpulseEngineWorkingTime.Cost + JumpEngineWorkingTime.Cost;

        return new TripResultInformation(new Success(), ActivePlasmaFuel.Cost, GravitonFuel.Cost, totalTime);
    }

    private void CountMeasurablesValuesAfterSpaceTravel(ISpaceShuttle shuttle, double totalDistance)
    {
        if (shuttle.ImpulseEngine is not null)
        {
            ActivePlasmaFuel.CalculateAndIncreaseMesurableValue(shuttle.ImpulseEngine, totalDistance);
            ImpulseEngineWorkingTime.CalculateAndIncreaseMesurableValue(shuttle.ImpulseEngine, totalDistance);
        }

        if (shuttle.JumpEngine is not null)
        {
            GravitonFuel.CalculateAndIncreaseMesurableValue(shuttle.JumpEngine, totalDistance);
            JumpEngineWorkingTime.CalculateAndIncreaseMesurableValue(shuttle.JumpEngine, totalDistance);
        }
    }
}