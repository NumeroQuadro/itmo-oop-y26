using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;

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

    public SpaceTravelResult? TakeDamage(double hitPoints)
    {
        if (HitPoints >= 0)
        {
            HitPoints -= hitPoints;
            return null;
        }

        return new ShuttleIsDestroyed();
    }
}