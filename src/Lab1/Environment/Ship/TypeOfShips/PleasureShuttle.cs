using Itmo.ObjectOrientedProgramming.Lab1.Asteroid;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Protection;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.TypeOfShips;

public class PleasureShuttle
{
    private readonly ShipHull _shipHull;

    public PleasureShuttle()
    {
        var deflector = new Deflector(ProtectionType.NoProtection, false);
        var engine = new Engine.Engine(EngineImpulseType.ImpulseClassC, EngineJumpType.NoJump);
        _shipHull = new ShipHull(ProtectionType.Class1, engine, deflector, false);
    }

    public EnvironmentType CurrentEnvironment { get; private set; }
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