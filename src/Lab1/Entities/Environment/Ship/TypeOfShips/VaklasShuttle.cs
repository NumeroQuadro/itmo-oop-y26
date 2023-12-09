using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.DeflectorType;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.Engine.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.Engine.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.ShipHullType;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.SpaceMovement;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.SpaceTravelResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.TypeOfShips;

public class VaklasShuttle : ISpaceShuttle
{
    public VaklasShuttle(PhotonicDeflector? photonicDeflector = null, NitrinoEmmiter? nitrinoEmmiter = null)
    {
        if (photonicDeflector is null)
        {
            Deflector = new AClassDeflector();
        }
        else
        {
            Deflector = photonicDeflector;
        }

        if (nitrinoEmmiter is null)
        {
            ShipHull = new BClassShipHull();
        }
        else
        {
            ShipHull = nitrinoEmmiter;
        }
    }

    public IImpulseEngine ImpulseEngine { get; } = new EClassImpulseEngine();
    public IJumpEngine JumpEngine { get; } = new GammaJumpEngine();
    public IShipHull ShipHull { get; }
    public IDeflector Deflector { get; }
    public SpaceTravelResult TakeDamageAndGetResult(double hitPoints)
    {
        if (Deflector.TakeDamageAndGetResult(hitPoints) is ProtectionState.ImpossibleToBeDamaged)
        {
            ProtectionState result = ShipHull.TakeDamage(hitPoints);

            return SpaceTravelResultAndProtectionConditionComparator(result);
        }

        return new SpaceTravelResult.Success();
    }

    private static SpaceTravelResult SpaceTravelResultAndProtectionConditionComparator(ProtectionState state)
    {
        if (state is ProtectionState.ImpossibleToBeDamaged)
        {
            return new SpaceTravelResult.ShuttleIsDestroyed();
        }

        return new SpaceTravelResult.Success();
    }
}