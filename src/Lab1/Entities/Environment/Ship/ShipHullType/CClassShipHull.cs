using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.ProtectionState;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.ShipHullType;

public class CClassShipHull : IShipHull
{
    public CClassShipHull(bool hasAntiNitrinoEmitter)
    {
        HasAntiNitrinoEmitter = hasAntiNitrinoEmitter;
        HitPoints = Constants.CClassShipHullHitPoints;
    }

    public bool HasAntiNitrinoEmitter { get; private set; }
    public double HitPoints { get; private set; }

    public ProtectionState TakeDamage(double hitPoints)
    {
        if (HitPoints <= 0 || hitPoints > HitPoints)
        {
            return new ImpossibleToBeDamaged();
        }

        HitPoints -= hitPoints;

        return new ProtectionIsEnabled();
    }
}