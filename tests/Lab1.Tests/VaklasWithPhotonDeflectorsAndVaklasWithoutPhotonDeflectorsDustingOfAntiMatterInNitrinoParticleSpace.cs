using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.EnvironmentTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Pathway;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.DeflectorType;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.TypeOfShips;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.SpaceMovement;
using Itmo.ObjectOrientedProgramming.Lab1.Models.SpaceTravelResults;
using Itmo.ObjectOrientedProgramming.Lab1.Services.ResultsHandler;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;
public class VaklasWithPhotonDeflectorsAndVaklasWithoutPhotonDeflectorsDustingOfAntiMatterInNitrinoParticleSpace
{
    private readonly IDictionary<string, ISpaceShuttle> _starshipsByName = new Dictionary<string, ISpaceShuttle>();

    public VaklasWithPhotonDeflectorsAndVaklasWithoutPhotonDeflectorsDustingOfAntiMatterInNitrinoParticleSpace()
    {
        var vaklasWithoutPhotonModification = new VaklasShuttle();
        var vaklasWithPhotonModification = new VaklasShuttle(new PhotonicDeflector(new AClassDeflector()));

        _starshipsByName.Add("VaklasModified", vaklasWithPhotonModification);
        _starshipsByName.Add("Vaklas", vaklasWithoutPhotonModification);
    }

    [Theory]
    [InlineData("VaklasModified", true)]
    [InlineData("Vaklas", false)]
    public void ShipShouldNotDestroyedIfItHasAntiNitrinoEmitter(string shipName, bool isSuccess)
    {
        // Arrange
        bool shuttleExists = _starshipsByName.TryGetValue(shipName, out ISpaceShuttle? shuttle);
        IEnumerable<DustingOfAntiMatter> dustings = new[] { new DustingOfAntiMatter() };

        var segment = new Segment(new NebulaInHighDensitySpace(dustings), 2);
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
            Assert.IsType<SpaceTravelResult.CrewDeath>(shuttleResult.TravelResult);
            return;
        }

        Assert.IsType<SpaceTravelResult.Success>(shuttleResult.TravelResult);
    }
}
