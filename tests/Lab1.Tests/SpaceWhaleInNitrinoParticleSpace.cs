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
public class SpaceWhaleInNitrinoParticleSpace
{
    private readonly IDictionary<string, ISpaceShuttle> _starshipsByName = new Dictionary<string, ISpaceShuttle>();
    private readonly AvgurShuttle _avgur;
    private readonly VaklasShuttle _vaklas;
    private readonly MeredianShuttle _meredian;

    public SpaceWhaleInNitrinoParticleSpace()
    {
        _avgur = new AvgurShuttle();
        _vaklas = new VaklasShuttle();
        _meredian = new MeredianShuttle();

        _starshipsByName.Add("Avgur", _avgur);
        _starshipsByName.Add("Vaklas", _vaklas);
        _starshipsByName.Add("Meredian", _meredian);
    }

    [Theory]
    [InlineData("Avgur", true)]
    [InlineData("Vaklas", true)]
    [InlineData("Meredian", true)]
    public void ShipShouldNotDestroyedIfItHasAntiNitrinoEmitter(string shipName, bool isSuccess)
    {
        // Arrange
        bool shuttleExists = _starshipsByName.TryGetValue(shipName, out ISpaceShuttle? shuttle);

        IEnumerable<SpaceWhale> whales = new[] { new SpaceWhale() };
        var segment = new Segment(new NitrinoParticleNebula(whales), 3);
        IEnumerable<Segment> segments = new[] { segment };

        var route = new Route(segments);

        if (shuttle is null)
        {
            throw new ArgumentException("shuttle is null!!!");
        }

        // Act
        TripResultInformation shuttleResult = route.Travel(shuttle);

        // Assert
        Assert.NotNull(shuttle);

        Assert.True(shuttleExists);

        if (!isSuccess)
        {
            Assert.IsType<SpaceTravelResult.ShuttleIsDestroyed>(shuttleResult.TravelResult);
        }

        Assert.Equal(shuttleResult.TravelResult is SpaceTravelResult.Success, isSuccess);
    }
}