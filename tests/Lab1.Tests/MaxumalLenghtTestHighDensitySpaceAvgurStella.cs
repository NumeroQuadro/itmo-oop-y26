using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.EnvironmentTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.TypeOfShips;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.ResultsHandler;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class MaxumalLenghtTestHighDensitySpaceAvgurStella
{
    private readonly AvgurShuttle _avgur = new AvgurShuttle(false);
    private readonly StellaShuttle _stella = new StellaShuttle(false);

    [Fact]
    public void ShipShouldNotDestroyedIfItHasAntiNitrinoEmitter()
    {
        // Arrange
        IEnvironment environment = new NebulaInHighDensitySpace(0, 7);

        // Act
        TripResultInformation avgurShuttleResult = _avgur.FlyToEnvironmentAndGetResult(environment);
        TripResultInformation stellaShuttleResult = _stella.FlyToEnvironmentAndGetResult(environment);

        var resultsHandler = new ResultsHandler();

        resultsHandler.AddValue(avgurShuttleResult, _avgur);
        resultsHandler.AddValue(stellaShuttleResult, _stella);

        // Assert
        ISpaceShuttle? answerShuttle = resultsHandler.GetShuttleWhichIsMoreProfit(environment);

        Assert.IsType<StellaShuttle>(answerShuttle);
    }
}