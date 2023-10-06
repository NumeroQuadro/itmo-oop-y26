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

public class MeredianShuttle : ISpaceShuttle
{
    public MeredianShuttle(bool hasPhotonDeflectors)
    {
        Deflector = new BClassDeflector(hasPhotonDeflectors);
    }

    public IShipHull ShipHull { get; } = new BClassShipHull(true);
    public IImpulseEngine ImpulseEngine { get; } = new EClassImpulseEngine();
    public IJumpEngine JumpEngine { get; } = new GammaJumpEngine();
    public IDeflector Deflector { get; init; }

    public SpaceTravelResult? TakeDamageAndGetResult(double hitPoints)
    {
        ProtectionState.ProtectionState resultAfterDeflectorDamaged = Deflector.TakeDamage(hitPoints);
        if (resultAfterDeflectorDamaged is ImpossibleToBeDamaged)
        {
            if (ShipHull.TakeDamage(hitPoints) is ImpossibleToBeDamaged)
            {
                return new ShuttleIsDestroyed();
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
                return new CrewDeath();
            }

            return null;
        }

        return new CrewDeath();
    }

    public bool IsShuttleIsSuitableToHighDensitySpace() => false;
    public bool IsShuttleIsSuitableToSpace() => true;
    public bool IsShuttleIsSuitableToNitrinoParticleNebula() => true;

    public TripResultInformation FlyToEnvironmentAndGetResult(IEnvironment environment)
    {
        if (!IsShuttlePossibleToLocateInEnvironment(environment))
        {
            return new TripResultInformation(new ImpossibleToGoToEnvironment(), 0, 0, 0);
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
                return new TripResultInformation(result, ImpulseEngine.WastedFuel, JumpEngine.WastedGravitonFuel, traveledTime);
            }
        }

        return new TripResultInformation(new Success(), ImpulseEngine.WastedFuel, JumpEngine.WastedGravitonFuel, traveledTime);
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
            if (!IsShuttleIsSuitableToHighDensitySpace() || environment.Length > JumpEngine.MaxLength)
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