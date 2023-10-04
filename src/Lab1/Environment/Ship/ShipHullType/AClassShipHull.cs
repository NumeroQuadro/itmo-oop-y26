using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.ProtectionState;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.ShipHullType;

public class AClassShipHull : IShipHull
{
    public AClassShipHull(bool hasAntiNitrinoEmitter)
    {
        HasAntiNitrinoEmitter = hasAntiNitrinoEmitter;
        HitPoints = Constants.AClassShipHullHitPoints;
    }

    public bool HasAntiNitrinoEmitter { get; private set; }
    public double HitPoints { get; private set; }
    public ProtectionState.ProtectionState TakeDamage(double hitPoints)
    {
        if (HitPoints < 0 || hitPoints > HitPoints)
        {
            return new ImpossibleToBeDamaged();
        }

        return new ProtectionIsEnabled();
    }
}