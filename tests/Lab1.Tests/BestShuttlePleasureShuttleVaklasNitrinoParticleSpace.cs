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

public class BestShuttlePleasureShuttleVaklasNitrinoParticleSpace
{
    private readonly VaklasShuttle _vaklasShuttle = new VaklasShuttle();
    private readonly StellaShuttle _pleasureShuttle = new StellaShuttle();

    [Fact]
    public void ShipShouldNotDestroyedIfItHasAntiNitrinoEmitter()
    {
        // Arrange
        var segment = new Segment(new NitrinoParticleNebula(Enumerable.Empty<SpaceWhale>()), 3);
        IEnumerable<Segment> segments = new[] { segment };
        var route = new Route(segments);

        // Act
        TripResultInformation vaklasShuttleResult = route.Travel(_vaklasShuttle);
        TripResultInformation pleasureShuttleResult = route.Travel(_pleasureShuttle);

        TripResultInformation[] results = new[] { vaklasShuttleResult, pleasureShuttleResult };

        var resultsHandler = new ResultsHandler(results);

        ISpaceShuttle answer = resultsHandler.GetShipWithBestResult();

        // Assert
        Assert.IsType<VaklasShuttle>(answer);
    }
}