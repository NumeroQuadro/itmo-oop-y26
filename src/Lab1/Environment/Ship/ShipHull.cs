using System;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Protection.ProtectionTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship;

public class ShipHull
{
    private readonly MeteoroidProtectionType _meteoroidProtectionType;

    public ShipHull(MeteoroidProtectionType protectionType, Engine.Engine engine, bool hasAntiNitrinoEmitter)
    {
        Engine = engine ?? throw new ArgumentException("Engine is a null! Cannot initialize ShipHull by empty Engine");
        HasAntiNitrinoEmitter = hasAntiNitrinoEmitter;
        _meteoroidProtectionType = protectionType;

        AssignCounters();
    }

    public bool HasAntiNitrinoEmitter { get; private set; }
    public uint HitPoints { get; private set; }

    public Engine.Engine Engine { get; private set; }
    public uint MaxAsteroidCounter { get; private set; }
    public uint MaxMeteorCounter { get; private set; }

    private void AssignCounters()
    {
        MaxAsteroidCounter = 3;
        MaxMeteorCounter = 4;
    }
}