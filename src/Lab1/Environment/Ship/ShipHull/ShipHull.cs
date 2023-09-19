using System;
using Itmo.ObjectOrientedProgramming.Lab1.Asteroid;
using Itmo.ObjectOrientedProgramming.Lab1.ShipHull;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.ShipHull;

public class ShipHull
{
    private readonly ShipHullType _shipHullType;
    private readonly Deflector.Deflector _deflector;
    private readonly Engine.Engine _engine;

    private uint _smallAsteroidCounter;
    private uint _bigAsteroidCounter;
    private bool _isDestroyed;
    public ShipHull(ShipHullType shipHullType, Engine.Engine engine, Deflector.Deflector deflector)
    {
        _deflector = deflector ?? throw new ArgumentException("Deflector is a null! Cannot initialize ShipHull by empty Deflector!");
        _engine = engine ?? throw new ArgumentException("Engine is a null! Cannot initialize ShipHull by empty Engine");

        _smallAsteroidCounter = 0;
        _bigAsteroidCounter = 0;

        _isDestroyed = false;
        _shipHullType = shipHullType;
    }

    public void TakeDamage(ObstacleType obstacleType)
    {
        if (DeflectorIsEnable())
        {
            RedirectDamageToDeflector(obstacleType: obstacleType);
        }
        else
        {
            const uint numberOfAsteroids = 1;
            IncrementAsteroidCounter(incrementNumber: numberOfAsteroids, obstacleType: obstacleType);
        }
    }

    private bool DeflectorIsEnable()
    {
        return _deflector.IsEnable;
    }

    private void RedirectDamageToDeflector(ObstacleType obstacleType)
    {
        _deflector.TakeDamage(obstacleType);
    }

    private void CheckBigAsteroidDamage()
    {
        switch (_shipHullType)
        {
            case ShipHullType.Class2:
                const uint class2HullCapacityBigAsteroids = 2;

                if (_bigAsteroidCounter == class2HullCapacityBigAsteroids)
                {
                    _isDestroyed = true;
                }

                break;
            case ShipHullType.Class3:
                const uint class3HullCapacityBigAsteroids = 5;

                if (_bigAsteroidCounter == class3HullCapacityBigAsteroids)
                {
                    _isDestroyed = true;
                }

                break;

            default:
                _isDestroyed = false;
                break;
        }
    }

    private void CheckSmallAsteroidDamage()
    {
        switch (_shipHullType)
        {
            case ShipHullType.Class1:
                const uint class1HullCapacitySmallAsteroids = 1;

                if (_smallAsteroidCounter == class1HullCapacitySmallAsteroids)
                {
                    _isDestroyed = true;
                }

                break;
            case ShipHullType.Class2:
                const uint class2HullCapacitySmallAsteroids = 5;

                if (_smallAsteroidCounter == class2HullCapacitySmallAsteroids)
                {
                    _isDestroyed = true;
                }

                break;
            case ShipHullType.Class3:
                const uint class3HullCapacitySmallAsteroids = 20;

                if (_smallAsteroidCounter == class3HullCapacitySmallAsteroids)
                {
                    _isDestroyed = true;
                }

                break;
        }
    }

    private void IncrementAsteroidCounter(uint incrementNumber, ObstacleType obstacleType)
    {
        if (!_isDestroyed)
        {
            if (obstacleType == ObstacleType.Meteor)
            {
                _bigAsteroidCounter += incrementNumber;
                CheckBigAsteroidDamage();
            }
            else
            {
                _smallAsteroidCounter += incrementNumber;
                CheckSmallAsteroidDamage();
            }
        }
    }
}