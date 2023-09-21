using System;
using Itmo.ObjectOrientedProgramming.Lab1.Asteroid;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Protection;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship;

public abstract class SpaceShuttle
{
    private readonly ShipHull _shipHull;

    protected SpaceShuttle(ShipHull shipHull, EnvironmentType environmentType)
    {
        _shipHull = shipHull ?? throw new ArgumentException("shipHull is null! Cannot initialize Ship!");
        CurrentEnvironment = environmentType;
    }

    protected SpaceShuttle(ShipHull shipHull)
    {
        _shipHull = shipHull ?? throw new ArgumentException("shipHull is null! Cannot initialize Ship!");
        CurrentEnvironment = EnvironmentType.Spawn;
    }

    protected SpaceShuttle(EnvironmentType environmentType)
    {
        CurrentEnvironment = environmentType;
    }

    public EnvironmentType CurrentEnvironment { get; private set; }
    public bool IsDestroyed { get; private set; }

    public ProtectionCondition TakeDamageAndGetSpaceShuttleCondition(ObstacleType obstacleType)
    {
        if (IsDestroyed)
        {
            return new IsDestroyed();
        }

        if (_shipHull.TakeDamageAndGetShipHullCondition(obstacleType) is IsDestroyed)
        {
            IsDestroyed = true;
            return new IsDestroyed();
        }

        return new IsWorking();
    }
}