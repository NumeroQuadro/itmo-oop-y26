using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.EnvironmentTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.DeflectorType;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Engine.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Engine.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.ProtectionState;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.ShipHullType;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.TypeOfShips;

public class AvgurShuttle : ISpaceShuttle
{
    private readonly IShipHull _shipHull = new CClassShipHull(false);
    private readonly EClassImpulseEngine _impulseEngine = new EClassImpulseEngine();
    private readonly AlphaJumpEngine _jumpEngine = new AlphaJumpEngine();
    private readonly IDeflector _deflector;

    public AvgurShuttle(bool hasPhotonDeflectors)
    {
        _deflector = new CClassDeflector(hasPhotonDeflectors);
    }

    public IEnvironment CurrentEnvironment { get; init; } = new Space();
    public bool HasPhotonModificator => _deflector.HasPhotonModification;
    public bool HasAntiNitrinoEmitter => _shipHull.HasAntiNitrinoEmitter;

    public SpaceTravelResult? TakeDamageAndGetResult(double hitPoints)
    {
        if (_deflector.TakeDamage(hitPoints) is ImpossibleToBeDamaged)
        {
            if (_shipHull.TakeDamage(hitPoints) is ImpossibleToBeDamaged)
            {
                return new ShuttleIsDestroyed();
            }
        }

        return null;
    }

    public bool IsShuttleIsSuitableToHighDensitySpace() => true;
    public bool IsShuttleIsSuitableToSpace() => true;
    public bool IsShuttleIsSuitableToNitrinoParticleNebula() => true;

    public SpaceTravelResult? FlyToEnvironmentAndGetResult(IEnvironment environment)
    {
        if (!IsShuttlePossibleToLocateInEnvironment(environment))
        {
            return new ImpossibleToGoToEnvironment();
        }

        IMovement.StartEngines(_impulseEngine, _jumpEngine, environment);

        IEnumerable<IObstacle> obstacles = environment.GetObstacles();

        foreach (IObstacle obstacle in obstacles)
        {
            SpaceTravelResult? result = obstacle.DealDamageAndGetShipCondition(this);
            if (result != null)
            {
                return result;
            }
        }

        return null;
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