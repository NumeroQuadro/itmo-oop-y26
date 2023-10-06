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

public class VaklasShuttle : ISpaceShuttle
{
    public VaklasShuttle(bool hasPhotonDeflectors)
    {
        Deflector = new AClassDeflector(hasPhotonDeflectors);
    }

    public IImpulseEngine ImpulseEngine { get; } = new EClassImpulseImpulseEngine();
    public IJumpEngine JumpEngine { get; } = new GammaJumpImpulseEngine();
    public IShipHull ShipHull { get; } = new BClassShipHull(false);
    public IDeflector Deflector { get; init; }
    public SpaceTravelResult? TakeDamageAndGetResult(double hitPoints)
    {
        ProtectionState.ProtectionState resultAfterDeflectorDamaged = Deflector.TakeDamage(hitPoints);
        if (resultAfterDeflectorDamaged is ImpossibleToBeDamaged)
        {
            if (ShipHull.TakeDamage(hitPoints) is ImpossibleToBeDamaged)
            {
                return new ShuttleIsDestroyed(Constants.ZeroBurnedFuel, Constants.ZeroBurnedFuel, Constants.ZeroTraveledTime);
            }
        }

        return null;
    }

    public SpaceTravelResult? TakeSpecialDamageAndGetResult(double hitPoints)
    {
        if (Deflector.HasPhotonModification)
        {
            if (Deflector.TakeSpecialDamage(hitPoints) is ImpossibleToBeDamaged)
            {
                return new CrewDeath(Constants.ZeroBurnedFuel, Constants.ZeroBurnedFuel, Constants.ZeroTraveledTime);
            }

            return null;
        }

        return new CrewDeath(Constants.ZeroBurnedFuel, Constants.ZeroBurnedFuel, Constants.ZeroTraveledTime);
    }

    public bool IsShuttleIsSuitableToHighDensitySpace() => true;
    public bool IsShuttleIsSuitableToSpace() => true;
    public bool IsShuttleIsSuitableToNitrinoParticleNebula() => true;

    public SpaceTravelResult FlyToEnvironmentAndGetResult(IEnvironment environment)
    {
        if (!IsShuttlePossibleToLocateInEnvironment(environment))
        {
            return new ImpossibleToGoToEnvironment(Constants.ZeroBurnedFuel, Constants.ZeroBurnedFuel, Constants.ZeroTraveledTime);
        }

        IMovement.StartEngines(ImpulseEngine, JumpEngine, environment);
        double traveledTime = 0;

        IEnumerable<IObstacle> obstacles = environment.GetObstacles();
        if (environment is not NebulaInHighDensitySpace)
        {
            traveledTime += ImpulseEngine.GetTravelTime(environment.Length);
        }
        else
        {
            traveledTime += JumpEngine.GetTravelTime(environment.Length);
        }

        foreach (IObstacle obstacle in obstacles)
        {
            SpaceTravelResult? result = obstacle.DealDamageAndGetShipCondition(this);
            if (result != null)
            {
                return result;
            }
        }

        return new Success(ImpulseEngine.WastedFuel, JumpEngine.WastedGravitonFuel, traveledTime);
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