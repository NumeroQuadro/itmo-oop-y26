using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.EnvironmentTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;
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
    private readonly CClassImpulseImpulseEngine _impulseImpulseEngine = new CClassImpulseImpulseEngine();

    public IImpulseEngine ImpulseEngine { get; } = new CClassImpulseImpulseEngine();
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

    public SpaceTravelResult? TakeSpecialDamageAndGetResult(double hitPoints)
    {
        return new CrewDeath();
    }

    public bool IsShuttleIsSuitableToHighDensitySpace() => false;
    public bool IsShuttleIsSuitableToSpace() => true;
    public bool IsShuttleIsSuitableToNitrinoParticleNebula() => false;

    public SpaceTravelResult FlyToEnvironmentAndGetResult(IEnvironment environment)
    {
        if (!IsShuttlePossibleToLocateInEnvironment(environment))
        {
            return new ImpossibleToGoToEnvironment();
        }

        IMovement.StartEngines(_impulseImpulseEngine, null, environment);
        double traveledTime = 0;

        IEnumerable<IObstacle> obstacles = environment.GetObstacles();
        if (environment is NebulaInHighDensitySpace)
        {
            return new ShuttleLost();
        }

        traveledTime += _impulseImpulseEngine.GetTravelTime(environment.Length);

        foreach (IObstacle obstacle in obstacles)
        {
            SpaceTravelResult? result = obstacle.DealDamageAndGetShipCondition(this);
            if (result != null)
            {
                return result;
            }
        }

        return new Success(_impulseImpulseEngine.WastedFuel, 0, traveledTime);
    }

    private bool IsShuttlePossibleToLocateInEnvironment(IEnvironment environment)
    {
        if (environment is Space)
        {
            if (!IsShuttleIsSuitableToSpace())
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