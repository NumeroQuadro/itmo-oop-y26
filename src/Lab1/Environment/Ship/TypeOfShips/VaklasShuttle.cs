using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.EnvironmentTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.DeflectorType;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.ProtectionState;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.ShipHullType;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.TypeOfShips;

public class VaklasShuttle : ISpaceShuttle
{
    // private readonly Engine.Engine _engine = new(new ImpulseClassC(), new NoJump());
    private readonly IShipHull _shipHull = new BClassShipHull(false);
    private readonly IDeflector _deflector = new AClassDeflector(false);

    public bool HasPhotonModificator => _deflector.HasPhotonModification;
    public bool HasAntiNitrinoEmitter => _shipHull.HasAntiNitrinoEmitter;

    public IEnvironment CurrentEnvironment { get; init; } = new Space();

    public SpaceTravelResult? FlyToEnvironmentAndGetResult(IEnvironment environment)
    {
        IEnumerable<IObstacle> obstacles = environment.GetObstacles();

        foreach (IObstacle obstacle in obstacles)
        {
            SpaceTravelResult? result = obstacle.DealDamageAndGetShipCondition(this);
            if (result != null)
            {
                return result;
            }
        }

        return null;
    }

    public SpaceTravelResult? TakeDamageAndGetResult(double hitPoints)
    {
        if (_deflector.TakeDamage(hitPoints) is ProtectionDisabled)
        {
            if (_shipHull.TakeDamage(hitPoints) is ProtectionDisabled)
            {
                return new ShuttleIsDestroyed();
            }

            return null;
        }

        return null;
    }
}