using Itmo.ObjectOrientedProgramming.Lab1.Environment.EnvironmentTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;

public class DustingOfAntiMatter : INebulaInHighDensitySpaceObstacle
{
    public DustingOfAntiMatter(IEnvironment environment)
    {
        CurrentEnvironment = environment;
    }
    
    public IEnvironment CurrentEnvironment { get; init; }
    
    public void DealDamage()
    {
        
    }
}