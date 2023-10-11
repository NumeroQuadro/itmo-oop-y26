using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.EnvironmentTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.EnvironmentTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Pathway;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.TypeOfShips;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;
using Itmo.ObjectOrientedProgramming.Lab1.Models.SpaceTravelResults;
using Itmo.ObjectOrientedProgramming.Lab1.Services.ResultsHandler;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class VaklasRouteOfThreeSegmentsWithAsteroidsAndMeteors
{
    private readonly IDictionary<string, ISpaceShuttle> _starshipsByName = new Dictionary<string, ISpaceShuttle>();
    private readonly VaklasShuttle _vaklas;

    public VaklasRouteOfThreeSegmentsWithAsteroidsAndMeteors()
    {
        _vaklas = new VaklasShuttle(false);

        _starshipsByName.Add("Vaklas", _vaklas);
    }

    [Theory]
    [InlineData("Vaklas")]
    public void ShipShouldNotDestroyedIfItHasAntiNitrinoEmitter(string shipName)
    {
        // Arrange
        bool shuttleExists = _starshipsByName.TryGetValue(shipName, out ISpaceShuttle? shuttle);
        var oneMeteoroidSpace = new Space(1, 1, 45);
        var zeroMeteoroidSpace = new Space(0, 0, 30);
        var killerSpace = new Space(10, 4, 45);

        var first_environments = new List<IEnvironment>();
        first_environments.Add(oneMeteoroidSpace);
        first_environments.Add(zeroMeteoroidSpace);
        first_environments.Add(killerSpace);

        var second_environments = new List<IEnvironment>();

        var twoMeteoroidSpace = new Space(2, 2, 23);
        var secondZeroMeteoroidSpace = new Space(0, 0, 33);
        second_environments.Add(twoMeteoroidSpace);
        second_environments.Add(secondZeroMeteoroidSpace);

        var first_segment = new PathSegment(first_environments);
        var second_segment = new PathSegment(second_environments);
        var segments = new List<PathSegment>();
        segments.Add(first_segment);
        segments.Add(second_segment);

        var route = new Route(segments);

        // Act
        TripResultInformation? routeResult = route.GoThroughAllSegmentsAndGetResultOfTrip(shuttle);

        // Assert
        Assert.NotNull(shuttle);

        Assert.True(shuttleExists);

        Assert.IsType<ShuttleIsDestroyed>(routeResult?.TravelResult);
    }
}