using System;
using Itmo.ObjectOrientedProgramming.Lab1.Asteroid;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship;

public class SpaceShip
{
    private readonly ShipHull.ShipHull _shipHull;

    public SpaceShip(ShipHull.ShipHull shipHull, EnvironmentType environmentType)
    {
        _shipHull = shipHull ?? throw new ArgumentException("shipHull is null! Cannot initialize Ship!");
        CurrentEnvironment = environmentType;
    }

    public SpaceShip(ShipHull.ShipHull shipHull)
    {
        _shipHull = shipHull ?? throw new ArgumentException("shipHull is null! Cannot initialize Ship!");
        CurrentEnvironment = EnvironmentType.Spawn;
    }

    public EnvironmentType CurrentEnvironment { get; private set; }

    public void TakeDamage(ObstacleType obstacleType)
    {
        _shipHull.TakeDamage(obstacleType: obstacleType);
    }
}