using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.EnvironmentTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Pathway;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.TypeOfShips;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.SpaceMovement;
using Itmo.ObjectOrientedProgramming.Lab1.Models.SpaceTravelResults;
using Itmo.ObjectOrientedProgramming.Lab1.Services.ResultsHandler;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class ShuttlesDestroyedAvgurPleasureShuttleInHighDensitySpace
{
    private readonly IDictionary<string, ISpaceShuttle> _starshipsByName = new Dictionary<string, ISpaceShuttle>();
    private readonly AvgurShuttle _avgur = new AvgurShuttle();
    private readonly PleasureShuttle _pleasure = new PleasureShuttle();

    public ShuttlesDestroyedAvgurPleasureShuttleInHighDensitySpace()
    {
        _starshipsByName.Add("Avgur", _avgur);
        _starshipsByName.Add("Pleasure", _pleasure);
    }

    [Theory]
    [InlineData("Avgur", false)]
    [InlineData("Pleasure", false)]
    public void ShipShouldNotDestroyedIfItHasAntiNitrinoEmitter(string shipName, bool isSuccess)
    {
        // Arrange
        bool shuttleExists = _starshipsByName.TryGetValue(shipName, out ISpaceShuttle? shuttle);

        IEnumerable<DustingOfAntiMatter> dustings = new[] { new DustingOfAntiMatter() };
        var segment = new Segment(new NebulaInHighDensitySpace(dustings), 7);
        IEnumerable<Segment> segments = new[] { segment };

        var route = new Route(segments);

        if (shuttle is null)
        {
            throw new ArgumentException("shuttle is null!!!");
        }

        // Act
        TripResultInformation shuttleResult = route.Travel(shuttle);

        // Assert
        Assert.True(shuttleExists);

        if (!isSuccess)
        {
            Assert.IsNotType<SpaceTravelResult.Success>(shuttleResult.TravelResult);
        }
    }
}