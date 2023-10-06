using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.EnvironmentTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.ResultsHandler;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.TypeOfShips;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement.SpaceTravelResults;
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
        _avgur = new AvgurShuttle(false);
        _vaklas = new VaklasShuttle(false);
        _meredian = new MeredianShuttle(false);

        _starshipsByName.Add("Avgur", _avgur);
        _starshipsByName.Add("Vaklas", _vaklas);
        _starshipsByName.Add("Meredian", _meredian);
    }

    [Theory]
    [InlineData("Avgur", true)]
    [InlineData("Vaklas", false)]
    [InlineData("Meredian", true)]
    public void ShipShouldNotDestroyedIfItHasAntiNitrinoEmitter(string shipName, bool isSuccess)
    {
        // Arrange
        bool shuttleExists = _starshipsByName.TryGetValue(shipName, out ISpaceShuttle? shuttle);
        var environment = new NitrinoParticleNebula(1, 3476);

        // Act
        TripResultInformation? shuttleResult = shuttle?.FlyToEnvironmentAndGetResult(environment);

        // Assert
        Assert.NotNull(shuttle);

        Assert.True(shuttleExists);

        if (!isSuccess)
        {
            Assert.IsType<ShuttleIsDestroyed>(shuttleResult?.TravelResult);
        }

        Assert.Equal(shuttleResult?.TravelResult is Success, isSuccess);
    }
}