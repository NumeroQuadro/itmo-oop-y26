using System;
using Itmo.ObjectOrientedProgramming.Lab1.Asteroid;

namespace Itmo.ObjectOrientedProgramming.Lab1.ShipHull;

public class ShipHull
{
    private readonly ShipHullType _shipHullType;

    private uint _smallAsteroidCounter;
    private uint _bigAsteroidCounter;
    private bool _isDestroyed;
    private Engine.Engine _engine;

    public ShipHull(ShipHullType shipHullClass, Engine.Engine engine)
    {
        if (engine == null)
        {
            throw new ArgumentException("Engine is a null!");
        }

        _engine = engine;

        _smallAsteroidCounter = 0;
        _bigAsteroidCounter = 0;

        _isDestroyed = false;
        _shipHullType = shipHullClass;
    }

    public void TakeDamage(MeteoroidType meteoroidType)
    {
        const uint oneAsteroidNumber = 1;

        IncrementAsteroidCounter(incrementNumber: oneAsteroidNumber, meteoroidType: meteoroidType);
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

    private void IncrementAsteroidCounter(uint incrementNumber, MeteoroidType meteoroidType)
    {
        if (!_isDestroyed)
        {
            if (meteoroidType == MeteoroidType.Meteor)
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