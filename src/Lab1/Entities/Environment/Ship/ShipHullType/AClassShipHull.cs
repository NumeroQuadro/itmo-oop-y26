using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.ShipHullType;

public class AClassShipHull : IShipHull
{
    public AClassShipHull(bool hasAntiNitrinoEmitter)
    {
        HasAntiNitrinoEmitter = hasAntiNitrinoEmitter;
        HitPoints = Constants.AClassShipHullHitPoints;
    }

    public bool HasAntiNitrinoEmitter { get; private set; }
    public double HitPoints { get; private set; }
    public ProtectionState TakeDamage(double hitPoints)
    {
        if (HitPoints <= 0 || hitPoints > HitPoints)
        {
            return new ProtectionState.ImpossibleToBeDamaged();
        }

        HitPoints -= hitPoints;

        return new ProtectionState.ProtectionIsEnabled();
    }
}