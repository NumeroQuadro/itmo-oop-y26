using System;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Protection;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Protection.ProtectionConditions;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Protection.ProtectionTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship;

public class ShipHull
{
    private readonly Deflector _deflector;
    private readonly Engine.Engine _engine;

    private readonly LightProtection _lightProtection;
    private readonly HeavyProtection _heavyProtection;

    public ShipHull(HeavyProtection heavyProtection, LightProtection lightProtection, Engine.Engine engine, Deflector deflector, bool hasAntiNitrinoEmitter)
    {
        _deflector = deflector ?? throw new ArgumentException("Deflector is a null! Cannot initialize ShipHull by empty Deflector!");
        _engine = engine ?? throw new ArgumentException("Engine is a null! Cannot initialize ShipHull by empty Engine");
        HasAntiNitrinoEmitter = hasAntiNitrinoEmitter;

        _lightProtection = lightProtection;
        _heavyProtection = heavyProtection;
    }

    public bool HasAntiNitrinoEmitter { get; private set; }
    public bool IsDestroyed { get; private set; }

    public ProtectionCondition TakeDamageAndGetShipHullCondition(ObstacleType obstacleType)
    {
        if (IsDestroyed)
        {
            return new IsDestroyed();
        }

        if (_deflector.TakeDamageAndGetDeflectorCondition(obstacleType) is IsDestroyed)
        {
            if (obstacleType is Meteor & _heavyProtection.ProtectionCondition() is IsWorking)
            {
                _heavyProtection.TakeDamage();
                return _heavyProtection.ProtectionCondition();
            }

            if (obstacleType is Asteroid & _lightProtection.ProtectionCondition() is IsWorking)
            {
                _lightProtection.TakeDamage();
                return _lightProtection.ProtectionCondition();
            }

            if (obstacleType is SpaceWhale)
            {
                if (HasAntiNitrinoEmitter)
                {
                    return new IsWorking();
                }

                return new IsDestroyed();
            }
        }

        return new IsWorking();
    }
}