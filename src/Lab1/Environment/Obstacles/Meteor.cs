using Itmo.ObjectOrientedProgramming.Lab1.Environment.EnvironmentTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;

public class Meteor : ISpaceObstacle
{
    public Meteor(IEnvironment environment)
    {
        CurrentEnvironment = environment;
    }
    
    public IEnvironment CurrentEnvironment { get; init; }
    
    public void DealDamage()
    {
        
    }
    
}