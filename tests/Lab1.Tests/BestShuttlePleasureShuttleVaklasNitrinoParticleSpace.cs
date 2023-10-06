using Itmo.ObjectOrientedProgramming.Lab1.Environment.EnvironmentTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.ResultsHandler;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.TypeOfShips;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class BestShuttlePleasureShuttleVaklasNitrinoParticleSpace
{
    private readonly VaklasShuttle _vaklasShuttle = new VaklasShuttle(false);
    private readonly StellaShuttle _pleasureShuttle = new StellaShuttle(false);

    [Fact]
    public void ShipShouldNotDestroyedIfItHasAntiNitrinoEmitter()
    {
        // Arrange
        IEnvironment environment = new NitrinoParticleNebula(0, 3);

        // Act
        TripResultInformation vaklasShuttleResult = _vaklasShuttle.FlyToEnvironmentAndGetResult(environment);
        TripResultInformation pleasureShuttleResult = _pleasureShuttle.FlyToEnvironmentAndGetResult(environment);

        var resultsHandler = new ResultsHandler();

        resultsHandler.AddValue(vaklasShuttleResult, _vaklasShuttle);
        resultsHandler.AddValue(pleasureShuttleResult, _pleasureShuttle);

        // Assert
        ISpaceShuttle? answerShuttle = resultsHandler.GetShuttleWhichIsMoreProfit(environment);

        Assert.IsType<VaklasShuttle>(answerShuttle);
    }
}