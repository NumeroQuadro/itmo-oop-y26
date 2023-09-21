using Itmo.ObjectOrientedProgramming.Lab1.Asteroid;

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

    // public void DamageShip(SpaceShuttle shuttle)
    // {
    //     if (shuttle == null)
    //     {
    //         throw new ArgumentException("Ship is a null! Cannot to Damage ship");
    //     }
    //
    //     if (IsPossibleToDamage(shuttle))
    //     {
    //         shuttle.TakeDamageAndGetSpaceShuttleCondition(obstacleType: _obstacleType);
    //     }
    // }

    // private bool IsPossibleToDamage(SpaceShuttle shuttle)
    // {
    //     return shuttle.CurrentEnvironment == CurrentEnvironment;
    // }
}