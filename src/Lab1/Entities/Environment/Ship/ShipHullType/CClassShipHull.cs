using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.ShipHullType;

public class CClassShipHull : IShipHull
{
    private const double CClassShipHullHitPoints = 100;
    public CClassShipHull()
    {
        HitPoints = CClassShipHullHitPoints;
    }

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