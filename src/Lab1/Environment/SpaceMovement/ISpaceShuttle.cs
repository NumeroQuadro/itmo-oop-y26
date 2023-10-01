using Itmo.ObjectOrientedProgramming.Lab1.Environment.EnvironmentTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Protection.ProtectionConditions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;

public interface ISpaceShuttle : IFly
{
    public IEnvironment CurrentEnvironment { get; init; }
    public ProtectionCondition? TakeDamageAndGetResult(double hitPoints);

    // protected bool IsPossibleToStayInHighDensitySpace();
    // protected bool IsPossibleToStayInSpace();
    // protected bool IsPossibleToStayInNitrinoParticleNebula();
}