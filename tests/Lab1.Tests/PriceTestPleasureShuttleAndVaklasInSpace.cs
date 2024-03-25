using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.EnvironmentTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Pathway;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.TypeOfShips;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.SpaceMovement;
using Itmo.ObjectOrientedProgramming.Lab1.Services.ResultsHandler;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class PriceTestPleasureShuttleAndVaklasInSpace
{
    private readonly VaklasShuttle _vaklas = new();
    private readonly PleasureShuttle _pleasureShuttle = new();

    [Fact]
    public void ShipShouldNotDestroyedIfItHasAntiNitrinoEmitter()
    {
        // Arrange
        var segment = new Segment(new Space(Enumerable.Empty<ISpaceObstacle>()), 2);
        IEnumerable<Segment> segments = new[] { segment };
        var route = new Route(segments);

        // Act
        TripResultInformation pleasureShuttleResult = route.Travel(_pleasureShuttle);
        TripResultInformation vaklasShuttleResult = route.Travel(_vaklas);

        TripResultInformation[] results = new[] { pleasureShuttleResult, vaklasShuttleResult };

        var resultsHandler = new ResultsHandler(results);
        ISpaceShuttle answer = resultsHandler.GetShipWithBestResult();

        // Assert
        Assert.IsType<PleasureShuttle>(answer);
    }
}