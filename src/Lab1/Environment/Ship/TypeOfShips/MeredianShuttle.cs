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

public class MeredianShuttle : ISpaceShuttle
{
    private readonly IShipHull _shipHull = new BClassShipHull(true);
    private readonly EClassImpulseEngine _impulseEngine = new EClassImpulseEngine();
    private readonly GammaJumpEngine _jumpEngine = new GammaJumpEngine();
    private readonly IDeflector _deflector = new BClassDeflector(false);

    public IEnvironment CurrentEnvironment { get; init; } = new Space();
    public bool HasPhotonModificator => _deflector.HasPhotonModification;
    public bool HasAntiNitrinoEmitter => _shipHull.HasAntiNitrinoEmitter;

    public SpaceTravelResult? TakeDamageAndGetResult(double hitPoints)
    {
        if (_deflector.TakeDamage(hitPoints) is ProtectionDisabled)
        {
            if (_shipHull.TakeDamage(hitPoints) is ProtectionDisabled)
            {
                return new ShuttleIsDestroyed();
            }
        }

        return null;
    }

    public SpaceTravelResult? FlyToEnvironmentAndGetResult(IEnvironment environment)
    {
        IEnumerable<IObstacle> obstacles = environment.GetObstacles();

        foreach (IObstacle obstacle in obstacles)
        {
            if ()
            SpaceTravelResult? result = obstacle.DealDamageAndGetShipCondition(this);
            if (result != null)
            {
                return result;
            }
        }

        return null;
    }
}