using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.EnvironmentTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Pathway;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.TypeOfShips;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Pathway;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.ResultsHandler;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;
using Itmo.ObjectOrientedProgramming.Lab1.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class MaxumalLenghtTestHighDensitySpaceAvgurStella
{
    private readonly AvgurShuttle _avgur = new AvgurShuttle(false);
    private readonly StellaShuttle _stella = new StellaShuttle(false);

    [Fact]
    public void ShipShouldNotDestroyedIfItHasAntiNitrinoEmitter()
    {
        // Arrange
        IEnvironment environment = new NebulaInHighDensitySpace(0, 7);
        IEnumerable<IEnvironment> environments = new[] { environment };
        var segment = new PathSegment(environments);
        IEnumerable<PathSegment> segments = new[] { segment };
        var route = new Route(segments);
        var flightSimulationForAvgur = new FlightSimulation(route, _avgur);
        var flightSimulationForStella = new FlightSimulation(route, _stella);

        // Act
        TripResultInformation avgurShuttleResult = flightSimulationForAvgur.StartSimulation();
        TripResultInformation stellaShuttleResult = flightSimulationForStella.StartSimulation();

        var resultsHandler = new ResultsHandler();

        resultsHandler.AddValue(avgurShuttleResult, _avgur);
        resultsHandler.AddValue(stellaShuttleResult, _stella);

        // Assert
        ISpaceShuttle answerShuttle = resultsHandler.GetShuttleWhichIsMoreProfit(environment);

        Assert.IsType<StellaShuttle>(answerShuttle);
    }
}