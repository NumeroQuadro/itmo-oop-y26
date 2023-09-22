namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;

public interface IFly
{
    public SpaceTravelResult ValidateShipCondition(IEnvironment environment);
    public SpaceTravelResult FlyToEnvironmentAndGetResult(IEnvironment environment);
    protected bool IsPossibleToStayInHighDensitySpace();
    protected bool IsPossibleToStayInSpace();
    protected bool IsPossibleToStayInNitrinoParticleNebula();
}