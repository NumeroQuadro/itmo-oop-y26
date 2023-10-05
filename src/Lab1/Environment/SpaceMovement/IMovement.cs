using Itmo.ObjectOrientedProgramming.Lab1.Environment.EnvironmentTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Engine;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;

public interface IMovement
{
    public bool IsShuttleIsSuitableToHighDensitySpace();
    public bool IsShuttleIsSuitableToSpace();
    public bool IsShuttleIsSuitableToNitrinoParticleNebula();
    protected static void StartEngines(IEngine? impulseEngine, IEngine? jumpEngine, IEnvironment environment)
    {
        if (environment is Space)
        {
            impulseEngine?.StartEngine();
        }
        else if (environment is NebulaInHighDensitySpace)
        {
            jumpEngine?.StartEngine();
        }
    }

    public SpaceTravelResult? FlyToEnvironmentAndGetResult(IEnvironment environment);
}