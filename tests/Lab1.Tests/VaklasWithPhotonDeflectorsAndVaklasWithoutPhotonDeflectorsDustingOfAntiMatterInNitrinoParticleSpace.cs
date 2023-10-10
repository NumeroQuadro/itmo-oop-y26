using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.EnvironmentTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Pathway;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.TypeOfShips;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Pathway;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.ResultsHandler;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement.SpaceTravelResults;
using Itmo.ObjectOrientedProgramming.Lab1.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;
public class VaklasWithPhotonDeflectorsAndVaklasWithoutPhotonDeflectorsDustingOfAntiMatterInNitrinoParticleSpace
{
    private readonly IDictionary<string, ISpaceShuttle> _starshipsByName = new Dictionary<string, ISpaceShuttle>();
    private readonly VaklasShuttle _vaklasWithPhotonModification;
    private readonly VaklasShuttle _vaklasWithoutPhotonModification;

    public VaklasWithPhotonDeflectorsAndVaklasWithoutPhotonDeflectorsDustingOfAntiMatterInNitrinoParticleSpace()
    {
        _vaklasWithoutPhotonModification = new VaklasShuttle(false);
        _vaklasWithPhotonModification = new VaklasShuttle(true);

        _starshipsByName.Add("VaklasModified", _vaklasWithPhotonModification);
        _starshipsByName.Add("Vaklas", _vaklasWithoutPhotonModification);
    }

    [Theory]
    [InlineData("VaklasModified", true)]
    [InlineData("Vaklas", false)]
    public void ShipShouldNotDestroyedIfItHasAntiNitrinoEmitter(string shipName, bool isSuccess)
    {
        // Arrange
        bool shuttleExists = _starshipsByName.TryGetValue(shipName, out ISpaceShuttle? shuttle);
        var environment = new NebulaInHighDensitySpace(1, 25);

        IEnumerable<IEnvironment> environments = new[] { environment };

        var segment = new PathSegment(environments);
        IEnumerable<PathSegment> segments = new[] { segment };

        var route = new Route(segments);

        if (shuttle is null)
        {
            throw new ArgumentException("shuttle is null!!!");
        }

        var flightSimulation = new FlightSimulation(route, shuttle);

        // Act
        TripResultInformation shuttleResult = flightSimulation.StartSimulation();

        // Assert
        Assert.NotNull(shuttle);

        Assert.True(shuttleExists);

        if (!isSuccess)
        {
            Assert.IsType<CrewDeath>(shuttleResult.TravelResult);
            return;
        }

        Assert.Equal(shuttleResult.TravelResult is Success, isSuccess);
    }
}
