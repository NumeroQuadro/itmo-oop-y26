using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.EnvironmentTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Pathway;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.TypeOfShips;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.SpaceMovement;
using Itmo.ObjectOrientedProgramming.Lab1.Models.SpaceTravelResults;
using Itmo.ObjectOrientedProgramming.Lab1.Services.ResultsHandler;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class VaklasRouteOfThreeSegmentsWithAsteroidsAndMeteors
{
    private readonly IDictionary<string, ISpaceShuttle> _starshipsByName = new Dictionary<string, ISpaceShuttle>();

    public VaklasRouteOfThreeSegmentsWithAsteroidsAndMeteors()
    {
        var vaklas = new VaklasShuttle();

        _starshipsByName.Add("Vaklas", vaklas);
    }

    [Theory]
    [InlineData("Vaklas")]
    public void ShipShouldNotDestroyedIfItHasAntiNitrinoEmitter(string shipName)
    {
        // Arrange
        IEnumerable<Asteroid> ten_asteroids = new[]
        {
            new Asteroid(), new Asteroid(), new Asteroid(), new Asteroid(), new Asteroid(), new Asteroid(),
            new Asteroid(), new Asteroid(), new Asteroid(), new Asteroid(),
        };

        IEnumerable<Meteor> four_meteors = new[]
        {
            new Meteor(), new Meteor(), new Meteor(), new Meteor(),
        };
        bool shuttleExists = _starshipsByName.TryGetValue(shipName, out ISpaceShuttle? shuttle);

        var first_segment = new Segment(new Space(ten_asteroids, Enumerable.Empty<Meteor>()), 3);
        var second_segment = new Segment(new Space(ten_asteroids, four_meteors), 3);
        var segments = new List<Segment>();
        segments.Add(first_segment);
        segments.Add(second_segment);

        var route = new Route(segments);

        // Act
        TripResultInformation? routeResult = route.Travel(shuttle);

        // Assert
        Assert.NotNull(shuttle);

        Assert.True(shuttleExists);

        Assert.IsType<SpaceTravelResult.ShuttleIsDestroyed>(routeResult?.TravelResult);
    }
}