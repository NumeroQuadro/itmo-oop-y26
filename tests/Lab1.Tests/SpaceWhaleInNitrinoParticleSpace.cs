using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.EnvironmentTypes;
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
    [InlineData("Meredian", false)]
    public void ShipShouldNotDestroyedIfItHasAntiNitrinoEmitter(string shipName, bool resultIsSuccess)
    {
        // Arrange
        bool shuttleExists = _starshipsByName.TryGetValue(shipName, out ISpaceShuttle? shuttle);
        var environment = new NitrinoParticleNebula(1, 34);

        // Act
        SpaceTravelResult? shuttleResult = shuttle?.FlyToEnvironmentAndGetResult(environment);

        // Assert
        Assert.NotNull(shuttle);

        Assert.True(shuttleExists);

        Assert.Equal(resultIsSuccess, shuttleResult is Success);
    }
}