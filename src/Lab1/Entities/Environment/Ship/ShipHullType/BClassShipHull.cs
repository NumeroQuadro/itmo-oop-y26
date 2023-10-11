using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.ProtectionState;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.ShipHullType;

public class BClassShipHull : IShipHull
{
    public BClassShipHull(bool hasAntiNitrinoEmitter)
    {
        HasAntiNitrinoEmitter = hasAntiNitrinoEmitter;
        HitPoints = Constants.BClassShipHullHitPoints;
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