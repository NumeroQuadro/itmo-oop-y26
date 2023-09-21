using System;
using Itmo.ObjectOrientedProgramming.Lab1.Asteroid;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Protection;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship;

public class ShipHull
{
    private readonly Deflector _deflector;
    private readonly Engine.Engine _engine;

    private readonly ProtectionType _protectionType;
    private readonly LightProtection _lightProtection;
    private readonly HeavyProtection _heavyProtection;

    public ShipHull(ProtectionType protectionType, Engine.Engine engine, Deflector deflector, bool hasAntiNitrinoEmitter)
    {
        _deflector = deflector ?? throw new ArgumentException("Deflector is a null! Cannot initialize ShipHull by empty Deflector!");
        _engine = engine ?? throw new ArgumentException("Engine is a null! Cannot initialize ShipHull by empty Engine");
        _protectionType = protectionType;
        HasAntiNitrinoEmitter = hasAntiNitrinoEmitter;

        _lightProtection = new LightProtection();
        _heavyProtection = protectionType == ProtectionType.Class1 ? new HeavyProtection(false) : new HeavyProtection(true);
    }

    public bool HasAntiNitrinoEmitter { get; private set; }

    public ProtectionCondition TakeDamageAndGetShipHullCondition(ObstacleType obstacleType)
    {
        if (_deflector.TakeDamageAndGetDeflectorCondition(obstacleType) is IsDestroyed)
        {
            if (obstacleType == ObstacleType.Meteor & _heavyProtection.ProtectionCondition() is IsWorking)
            {
                _heavyProtection.TakeDamage();
                return _heavyProtection.ProtectionCondition();
            }

            if (obstacleType == ObstacleType.SmallAsteroid & _lightProtection.ProtectionCondition() is IsWorking)
            {
                _lightProtection.TakeDamage();
                return _lightProtection.ProtectionCondition();
            }

            if (obstacleType == ObstacleType.SpaceWhale & HasAntiNitrinoEmitter)
            {
                return new IsWorking();
            }
        }

        return new IsDestroyed();
    }
}