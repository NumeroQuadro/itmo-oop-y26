using System;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.EnvironmentTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Engine.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Protection;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Protection.ProtectionConditions;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Protection.ProtectionTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.TypeOfShips;

public class VaklasShuttle : ISpaceShuttle
{
    private readonly ShipHull _shipHull;
    private readonly Deflector _deflector;
    public VaklasShuttle()
    {
        var engine = new Engine.Engine(new ImpulseClassC(), new NoJump());
        _deflector = new Deflector(new Class1(), false);
        _shipHull = new ShipHull(new Class2(), engine, false);
        IsDestroyed = false;

        CurrentEnvironment = new Space();
    }

    public IEnvironment CurrentEnvironment { get; init; }
    public bool IsDestroyed { get; private set; }
    public uint HitPoints { get; private set; }

    public ProtectionCondition TakeDamage(uint hitPoints)
    {
        if (hitPoints > HitPoints)
        {
            return new IsDestroyed();
        }

        return new IsWorking();
    }

    public void DestroyShuttle()
    {
        IsDestroyed = true;
    }

    public (uint, uint) GetShipHullCounters()
    {
        return (_shipHull.MaxAsteroidCounter, _shipHull.MaxMeteorCounter);
    }

    public (uint, uint) GetDeflectorCounter()
    {
        return (_deflector.MaxAsteroidCounter, _deflector.MaxMeteorCounter);
    }

    public bool IsDeflectorDestroyed()
    {
        return _deflector.IsDestroyed;
    }
    
    private void CalculateShipHitPoints(uint deflectorHitPoints, uint shipHullHitPoints)
    {
        HitPoints = deflectorHitPoints + shipHullHitPoints;
    }

    public void ShipHullTakeDamage()
    {
        
    }

    public void DeflectorTakeDamage(uint hitPoints)
    {
        _deflector.TakeDamage(hitPoints);
    }
}