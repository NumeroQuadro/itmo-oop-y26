using Itmo.ObjectOrientedProgramming.Lab1.Environment.EnvironmentTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;

public interface ISpaceShuttle : IFly
{
    public IEnvironment CurrentEnvironment { get; }
    public bool HasPhotonModificator { get; }
    public bool HasAntiNitrinoEmitter { get; }
    public SpaceTravelResult? TakeDamageAndGetResult(double hitPoints);

    // protected bool IsPossibleToStayInHighDensitySpace();
    // protected bool IsPossibleToStayInSpace();
    // protected bool IsPossibleToStayInNitrinoParticleNebula();
}