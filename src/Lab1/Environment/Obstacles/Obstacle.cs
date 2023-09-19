using Itmo.ObjectOrientedProgramming.Lab1.Asteroid;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public class Obstacle
{
    private readonly ObstacleType _obstacleType;
    private uint _numberInOneStack; // SpaceWhale >= 1, other = 1

    public Obstacle(ObstacleType obstacleType, uint numberInOneStack)
    {
        _obstacleType = obstacleType;
        _numberInOneStack = numberInOneStack;
    }

    public void DamageShip(SpaceShip ship)
    {
        // check for one environment as obstacle has
    }
}