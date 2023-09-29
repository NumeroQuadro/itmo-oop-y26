using Itmo.ObjectOrientedProgramming.Lab1.Environment.EnvironmentTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;

public interface IFly
{
    public SpaceTravelResult ValidateShipCondition(IEnvironment environment);
    public SpaceTravelResult FlyToEnvironmentAndGetResult(IEnvironment environment);
}