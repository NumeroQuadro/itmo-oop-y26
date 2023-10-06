using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.EnvironmentTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.ResultsHandler;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.TypeOfShips;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class PriceTestPleasureShuttleAndVaklasInSpace
{
    private readonly IDictionary<string, ISpaceShuttle> _starshipsByName = new Dictionary<string, ISpaceShuttle>();
    private readonly VaklasShuttle _vaklas;
    private readonly PleasureShuttle _pleasureShuttle;

    public PriceTestPleasureShuttleAndVaklasInSpace()
    {
        _vaklas = new VaklasShuttle(false);
        _pleasureShuttle = new PleasureShuttle();

        _starshipsByName.Add("Vaklas", _vaklas);
        _starshipsByName.Add("PleasureShuttle", _pleasureShuttle);
    }

    [Fact]
    public void ShipShouldNotDestroyedIfItHasAntiNitrinoEmitter()
    {
        // Arrange
        IEnvironment environment = new Space(0, 0, 45);

        // Act
        TripResultInformation pleasureShuttleResult = _pleasureShuttle.FlyToEnvironmentAndGetResult(environment);
        TripResultInformation vaklasShuttleResult = _vaklas.FlyToEnvironmentAndGetResult(environment);

        var resultsHandler = new ResultsHandler();

        resultsHandler.AddValue(pleasureShuttleResult, _pleasureShuttle);
        resultsHandler.AddValue(vaklasShuttleResult, _vaklas);

        // Assert
        ISpaceShuttle? answerShuttle = resultsHandler.GetShuttleWhichIsMoreProfit(environment);

        Assert.IsType<PleasureShuttle>(answerShuttle);
    }
}