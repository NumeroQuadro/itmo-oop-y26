using Itmo.ObjectOrientedProgramming.Lab1.Environment.EnvironmentTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;

public class Asteroid : ISpaceObstacle
{
    public Asteroid(IEnvironment environment)
    {
        CurrentEnvironment = environment;
    }
    
    public IEnvironment CurrentEnvironment { get; init; }

    public void DealDamage()
    {
        
    }
}