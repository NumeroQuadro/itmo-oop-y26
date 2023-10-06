using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.EnvironmentTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.EnvironmentTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.ResultsHandler;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.DeflectorType;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Engine.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Engine.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.ProtectionState;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.ShipHullType;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement.SpaceTravelResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.TypeOfShips;

public class PleasureShuttle : ISpaceShuttle
{
    public IImpulseEngine ImpulseEngine { get; } = new CClassImpulseEngine();
    public IJumpEngine? JumpEngine => null;
    public IShipHull ShipHull { get; } = new BClassShipHull(false);
    public IDeflector? Deflector => null;

    public SpaceTravelResult? TakeDamageAndGetResult(double hitPoints)
    {
        if (ShipHull.TakeDamage(hitPoints) is ImpossibleToBeDamaged)
        {
            return new ShuttleIsDestroyed();
        }

        return null;
    }

    public SpaceTravelResult TakeSpecialDamageAndGetResult(double hitPoints)
    {
        return new CrewDeath();
    }

    public bool IsShuttleIsSuitableToHighDensitySpace() => false;
    public bool IsShuttleIsSuitableToSpace() => true;
    public bool IsShuttleIsSuitableToNitrinoParticleNebula() => false;

    public TripResultInformation FlyToEnvironmentAndGetResult(IEnvironment environment)
    {
        double traveledTime = 0;

        if (!IsShuttlePossibleToLocateInEnvironment(environment))
        {
            return new TripResultInformation(new ImpossibleToGoToEnvironment(), ImpulseEngine.WastedFuel, 0, traveledTime);
        }

        IMovement.StartEngines(ImpulseEngine, null, environment);

        IEnumerable<IObstacle> obstacles = environment.GetObstacles();

        if (environment is NebulaInHighDensitySpace)
        {
            return new TripResultInformation(new ShuttleLost(), ImpulseEngine.WastedFuel, 0, traveledTime);
        }

        traveledTime += ImpulseEngine.GetTravelTime(environment.Length);

        foreach (IObstacle obstacle in obstacles)
        {
            SpaceTravelResult? result = obstacle.DealDamageAndGetShipCondition(this);
            if (result != null)
            {
                return new TripResultInformation(result, ImpulseEngine.WastedFuel, 0, traveledTime);
            }
        }

        return new TripResultInformation(new Success(), ImpulseEngine.WastedFuel, 0, traveledTime);
    }

    private bool IsShuttlePossibleToLocateInEnvironment(IEnvironment environment)
    {
        if (environment is Space)
        {
            if (!IsShuttleIsSuitableToSpace() || environment.Length > ImpulseEngine.MaxLength)
            {
                return false;
            }
        }
        else if (environment is NebulaInHighDensitySpace)
        {
            if (!IsShuttleIsSuitableToHighDensitySpace())
            {
                return false;
            }
        }
        else if (environment is NitrinoParticleNebula)
        {
            if (!IsShuttleIsSuitableToNitrinoParticleNebula())
            {
                return false;
            }
        }

        return true;
    }
}