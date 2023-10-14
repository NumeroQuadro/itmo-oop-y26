using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.DeflectorType;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.Engine.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.Engine.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.ShipHullType;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.SpaceMovement;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.SpaceTravelResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.TypeOfShips;

public class PleasureShuttle : ISpaceShuttle
{
    public IImpulseEngine ImpulseEngine { get; } = new CClassImpulseEngine();
    public IJumpEngine? JumpEngine => null;
    public IShipHull ShipHull { get; } = new BClassShipHull(false);
    public IDeflector? Deflector => null;

    public SpaceTravelResult TakeDamageAndGetResult(double hitPoints)
    {
        ProtectionState result = ShipHull.TakeDamage(hitPoints);

        return SpaceTravelResultAndProtectionConditionComparator(result);
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