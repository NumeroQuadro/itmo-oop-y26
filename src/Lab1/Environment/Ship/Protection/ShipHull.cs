using System;
using Itmo.ObjectOrientedProgramming.Lab1.Asteroid;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Protection;

public class ShipHull : Protection
{
    private readonly Deflector _deflector;
    private readonly Engine.Engine _engine;

    public ShipHull(ProtectionType protectionType, Engine.Engine engine, Deflector deflector, bool hasAntiNitrinoEmitter, uint asteroidCounter, uint meteorCounter, uint spaceWhaleCounter)
        : base(protectionType, asteroidCounter, meteorCounter, spaceWhaleCounter)
    {
        _deflector = deflector ?? throw new ArgumentException("Deflector is a null! Cannot initialize ShipHull by empty Deflector!");
        _engine = engine ?? throw new ArgumentException("Engine is a null! Cannot initialize ShipHull by empty Engine");

        HasAntiNitrinoEmitter = hasAntiNitrinoEmitter;
    }

    public bool HasAntiNitrinoEmitter { get; private set; }

    private uint SpaceWhaleCounter { get; set; }

    public void TakeDamage(ObstacleType obstacleType)
    {
        if (_deflector.HasPossibleToBeDamage(obstacleType))
        {
            _deflector.TakeDamage(obstacleType);
        }
        else
        {
            DecreaseDamageCounters(obstacleType);
        }
    }

    public bool HasPossibleToBeDamage(ObstacleType obstacleType)
    {
        if (obstacleType == ObstacleType.SpaceWhale)
        {
            return IsProtectionActive() & IsSpecialProtectionActive();
        }

        return IsProtectionActive();
    }

    private bool IsSpecialProtectionActive()
    {
        return SpaceWhaleCounter != 0;
    }

    private void DecrementSpaceWhaleCounter()
    {
        if (IsProtectionActive())
        {
            --SpaceWhaleCounter;
        }
    }

    private void DecreaseDamageCounters(ObstacleType obstacleType)
    {
        switch (obstacleType)
        {
            case ObstacleType.SmallAsteroid:
                DecrementAsteroidCounter();
                break;
            case ObstacleType.Meteor:
                DecrementMeteorCounter();
                break;
            default:
                DecrementSpaceWhaleCounter();
                break;
        }
    }
}