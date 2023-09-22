using Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Protection;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Protection.ProtectionConditions;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Protection.ProtectionTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.TypeOfShips;

public class VaklasShuttle
{
    private readonly ShipHull _shipHull;

    public VaklasShuttle()
    {
        var deflector = new Deflector(ProtectionType.NoProtection, false);
        var engine = new Engine.Engine(EngineImpulseType.ImpulseClassC, EngineJumpType.NoJump);
        _shipHull = new ShipHull(ProtectionType.Class1, engine, deflector, false);
    }

    // public EnvironmentType CurrentEnvironment { get; private set; }
    public bool IsDestroyed { get; private set; }

    public ProtectionCondition TakeDamageAndGetSpaceShuttleCondition(ObstacleType obstacleType)
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
}