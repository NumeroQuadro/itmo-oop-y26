using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.EnvironmentTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Pathway;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.TypeOfShips;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.SpaceMovement;
using Itmo.ObjectOrientedProgramming.Lab1.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Services.ResultsHandler;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class BestShuttlePleasureShuttleVaklasNitrinoParticleSpace
{
    private readonly VaklasShuttle _vaklasShuttle = new VaklasShuttle(false);
    private readonly StellaShuttle _pleasureShuttle = new StellaShuttle(false);

    [Fact]
    public void ShipShouldNotDestroyedIfItHasAntiNitrinoEmitter()
    {
        // Arrange
        IEnvironment environment = new NitrinoParticleNebula(0, 3);
        IEnumerable<IEnvironment> environments = new[] { environment };
        var segment = new Segment(environments);
        IEnumerable<Segment> segments = new[] { segment };
        var route = new Route(segments);
        var flightSimulationForVaklas = new FlightSimulation(route, _vaklasShuttle);
        var flighSimulationForPleasureShuttle = new FlightSimulation(route, _pleasureShuttle);

        // Act
        TripResultInformation vaklasShuttleResult = flightSimulationForVaklas.StartSimulation();
        TripResultInformation pleasureShuttleResult = flighSimulationForPleasureShuttle.StartSimulation();

        var resultsHandler = new ResultsHandler();

        resultsHandler.AddValue(vaklasShuttleResult, _vaklasShuttle);
        resultsHandler.AddValue(pleasureShuttleResult, _pleasureShuttle);

        // Assert
        ISpaceShuttle answerShuttle = resultsHandler.GetShuttleWhichIsMoreProfit(environment);

        Assert.IsType<VaklasShuttle>(answerShuttle);
    }
}