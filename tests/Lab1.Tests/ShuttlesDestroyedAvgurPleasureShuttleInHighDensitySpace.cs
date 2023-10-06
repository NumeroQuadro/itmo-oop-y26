using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.EnvironmentTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.ResultsHandler;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.TypeOfShips;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement.SpaceTravelResults;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class ShuttlesDestroyedAvgurPleasureShuttleInHighDensitySpace
{
    private readonly IDictionary<string, ISpaceShuttle> _starshipsByName = new Dictionary<string, ISpaceShuttle>();
    private readonly AvgurShuttle _avgur = new AvgurShuttle(false);
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
        var environment = new NebulaInHighDensitySpace(1, 7);

        // Act
        TripResultInformation? shuttleResult = shuttle?.FlyToEnvironmentAndGetResult(environment);

        // Assert
        Assert.NotNull(shuttle);

        Assert.True(shuttleExists);

        if (!isSuccess)
        {
            Assert.IsNotType<Success>(shuttleResult?.TravelResult);
        }
    }
}