using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.DeflectorType;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Engine.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Engine.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.ShipHullType;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;
using Itmo.ObjectOrientedProgramming.Lab1.Models.ProtectionState;
using Itmo.ObjectOrientedProgramming.Lab1.Models.SpaceTravelResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.TypeOfShips;

public class VaklasShuttle : ISpaceShuttle
{
    public VaklasShuttle(bool hasPhotonDeflectors)
    {
        Deflector = new AClassDeflector(hasPhotonDeflectors);
    }

    public IImpulseEngine ImpulseEngine { get; } = new EClassImpulseEngine();
    public IJumpEngine JumpEngine { get; } = new GammaJumpEngine();
    public IShipHull ShipHull { get; } = new BClassShipHull(false);
    public IDeflector Deflector { get; init; }
    public SpaceTravelResult? TakeDamageAndGetResult(double hitPoints)
    {
        ProtectionState resultAfterDeflectorDamaged = Deflector.TakeDamage(hitPoints);
        if (resultAfterDeflectorDamaged is ImpossibleToBeDamaged)
        {
            if (ShipHull.TakeDamage(hitPoints) is ImpossibleToBeDamaged)
            {
                return new ShuttleIsDestroyed();
            }
        }

        return null;
    }

    public SpaceTravelResult? TakeSpecialDamageAndGetResult(double hitPoints)
    {
        if (Deflector.HasPhotonModification)
        {
            if (Deflector.TakeSpecialDamage(hitPoints) is ImpossibleToBeDamaged)
            {
                return new CrewDeath();
            }

            return null;
        }

        return new CrewDeath();
    }
}