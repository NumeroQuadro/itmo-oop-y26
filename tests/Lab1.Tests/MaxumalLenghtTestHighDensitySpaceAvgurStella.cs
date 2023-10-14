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

public class MaxumalLenghtTestHighDensitySpaceAvgurStella
{
    private readonly AvgurShuttle _avgur = new();
    private readonly StellaShuttle _stella = new();

    [Fact]
    public void ShipShouldNotDestroyedIfItHasAntiNitrinoEmitter()
    {
        // Arrange
        var segment = new Segment(new NebulaInHighDensitySpace(Enumerable.Empty<DustingOfAntiMatter>()), 7);
        IEnumerable<Segment> segments = new[] { segment };
        var route = new Route(segments);

        // Act
        TripResultInformation avgurShuttleResult = route.Travel(_avgur);
        TripResultInformation stellaShuttleResult = route.Travel(_stella);

        TripResultInformation[] results = new[] { avgurShuttleResult, stellaShuttleResult };

        var resultsHandler = new ResultsHandler(results);

        ISpaceShuttle answer = resultsHandler.GetShipWithBestResult();

        // Assert
        Assert.IsType<AvgurShuttle>(answer);
    }
}