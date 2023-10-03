using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.DamageHandler;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.EnvironmentTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.DeflectorType;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Engine.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.ShipHullType;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.TypeOfShips;

public class VaklasShuttle : ISpaceShuttle
{
    private readonly Engine.Engine _engine;
    private readonly IShipHull _shipHull;
    private readonly IDeflector _deflector;
    private readonly DamageHandler.DamageHandler _damageHandler;

    public VaklasShuttle()
    {
        _engine = new Engine.Engine(new ImpulseClassC(), new NoJump());
        _deflector = new AClassDeflector(false);
        _shipHull = new BClassShipHull(false);
        _damageHandler = new DamageHandler.DamageHandler();
        _damageHandler.SetNextDamageHandler(new DeflectorDamageHandler(Constants.AClassDeflectorWithPhotonModificationHitPoints, Constants.BClassShipHullHitPoints));

        CurrentEnvironment = new Space();
    }

    public bool HasPhotonModificator => _deflector.HasPhotonModification;
    public bool HasAntiNitrinoEmitter => _shipHull.HasAntiNitrinoEmitter;

    public IEnvironment CurrentEnvironment { get; init; }

    public SpaceTravelResult? FlyToEnvironmentAndGetResult(IEnvironment environment)
    {
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

    public SpaceTravelResult? TakeDamageAndGetResult(double hitPoints)
    {
        return _damageHandler.DealDamage(hitPoints);
    }
}