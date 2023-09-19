using System;
using Itmo.ObjectOrientedProgramming.Lab1.Asteroid;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;

public class Obstacle
{
    private readonly ObstacleType _obstacleType;
    private uint _numberInOneStack; // SpaceWhale >= 1, other = 1
    public Obstacle(ObstacleType obstacleType, uint numberInOneStack, EnvironmentType environmentType)
    {
        _obstacleType = obstacleType;
        _numberInOneStack = numberInOneStack;
        CurrentEnvironment = environmentType;
    }

    public EnvironmentType CurrentEnvironment { get; private set; }

    public void DamageShip(SpaceShip ship)
    {
        if (ship == null)
        {
            throw new ArgumentException("Ship is a null! Cannot to Damage ship");
        }

        if (IsPossibleToDamage(ship))
        {
            ship.TakeDamage(obstacleType: _obstacleType);
        }
    }

    private bool IsPossibleToDamage(SpaceShip ship)
    {
        return ship.CurrentEnvironment == CurrentEnvironment;
    }
}