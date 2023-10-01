using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.DamageHandler;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.EnvironmentTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Engine.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Protection.ProtectionTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.TypeOfShips;

public class MeredianShuttle : ISpaceShuttle
{
    private readonly ShipHull _shipHull;
    private readonly Deflector _deflector;
    private readonly DamageHandler.DamageHandler _damageHandler;

    public MeredianShuttle()
    {
        var engine = new Engine.Engine(new ImpulseClassC(), new NoJump());
        _deflector = new Deflector(new Class1(), false);
        _shipHull = new ShipHull(new Class2(), engine, false);
        _damageHandler = new DamageHandler.DamageHandler();
        _damageHandler.SetNextDamageHandler(new DeflectorDamageHandler(Constants.BClassDeflectorWithoutPhotonModificationHitPoints, Constants.BClassShipHullHitPoints));

        CurrentEnvironment = new Space();
    }

    public IEnvironment CurrentEnvironment { get; init; }
    public bool HasPhotonModificator => _deflector.HasPhotonModification;
    public bool HasAntiNitrinoEmitter => _shipHull.HasAntiNitrinoEmitter;

    public SpaceTravelResult? TakeDamageAndGetResult(double hitPoints)
    {
        Console.WriteLine("ну я корабл, получаю дамаг");
        return _damageHandler.DealDamage(hitPoints);
    }

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
}