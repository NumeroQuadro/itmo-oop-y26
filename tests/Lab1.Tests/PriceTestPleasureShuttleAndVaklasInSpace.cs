using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.EnvironmentTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Pathway;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.TypeOfShips;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;
using Itmo.ObjectOrientedProgramming.Lab1.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Services.ResultsHandler;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class PriceTestPleasureShuttleAndVaklasInSpace
{
    private readonly VaklasShuttle _vaklas = new(false);
    private readonly PleasureShuttle _pleasureShuttle = new();

    [Fact]
    public void ShipShouldNotDestroyedIfItHasAntiNitrinoEmitter()
    {
        // Arrange
        IEnvironment environment = new Space(0, 0, 2);
        IEnumerable<IEnvironment> environments = new[] { environment };
        var segment = new PathSegment(environments);
        IEnumerable<PathSegment> segments = new[] { segment };
        var route = new Route(segments);
        var flightSimulationForPleasureShuttle = new FlightSimulation(route, _pleasureShuttle);
        var flightSimulationForVaklas = new FlightSimulation(route, _vaklas);

        // Act
        TripResultInformation pleasureShuttleResult = flightSimulationForPleasureShuttle.StartSimulation();
        TripResultInformation vaklasShuttleResult = flightSimulationForVaklas.StartSimulation();

        var resultsHandler = new ResultsHandler();

        resultsHandler.AddValue(pleasureShuttleResult, _pleasureShuttle);
        resultsHandler.AddValue(vaklasShuttleResult, _vaklas);

        // Assert
        ISpaceShuttle answerShuttle = resultsHandler.GetShuttleWhichIsMoreProfit(environment);

        Assert.IsType<PleasureShuttle>(answerShuttle);
    }
}