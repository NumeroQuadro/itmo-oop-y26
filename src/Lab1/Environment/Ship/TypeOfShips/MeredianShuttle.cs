using Itmo.ObjectOrientedProgramming.Lab1.Environment.EnvironmentTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Engine.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Protection;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Protection.ProtectionConditions;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Protection.ProtectionTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.TypeOfShips;

public class MeredianShuttle : ISpaceShuttle
{
    private readonly ShipHull _shipHull;

    public MeredianShuttle()
    {
        var deflector = new Deflector(new NoProtection(), false);
        var engine = new Engine.Engine(new ImpulseClassC(), new NoJump());
        _shipHull = new ShipHull(new HeavyProtection(false), new LightProtection(), engine, deflector, false);

        CurrentEnvironment = new Space();
    }

    public IEnvironment CurrentEnvironment { get; private set; }
    public bool IsDestroyed { get; private set; }

    public ProtectionCondition TakeDamageAndGetSpaceShuttleCondition(IObstacle obstacleType)
    {
        if (IsDestroyed)
        {
            return new IsDestroyed();
        }

        if (_shipHull.TakeDamageAndGetShipHullCondition(obstacleType) is IsDestroyed)
        {
            IsDestroyed = true;
            return new IsDestroyed();
        }

        return new IsWorking();
    }

    // add checks to destruction from ALL space obstacles and amount of fuel
    public bool IsPossibleToStayInHighDensitySpace()
    {
        return _shipHull.Engine.EngineJumpType is not NoJump;
    }

    // add checks to destruction from ALL space obstacles and amount of fuel
    public bool IsPossibleToStayInSpace()
    {
        return _shipHull.Engine.EngineImpulseType is ImpulseClassC or ImpulseClassE;
    }

    // add checks to destruction from ALL space obstacles and amount of fuel
    public bool IsPossibleToStayInNitrinoParticleNebula()
    {
        return _shipHull.Engine.EngineImpulseType is ImpulseClassE;
    }

    public SpaceTravelResult ValidateShipCondition(IEnvironment environment)
    {
        if (environment is NebulaInHighDensitySpace & IsPossibleToStayInHighDensitySpace())
        {
            return new Success();
        }

        if (environment is NitrinoParticleNebula & IsPossibleToStayInNitrinoParticleNebula())
        {
            return new Success();
        }

        if (environment is Space & IsPossibleToStayInSpace())
        {
            return new Success();
        }

        return
    }

    public SpaceTravelResult FlyToEnvironmentAndGetResult(IEnvironment environment)
    {

    }
}