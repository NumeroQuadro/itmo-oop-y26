using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.ShipHullType;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship;

public class AClassShipHull : IShipHull
{
    public AClassShipHull(bool hasAntiNitrinoEmitter)
    {
        HasAntiNitrinoEmitter = hasAntiNitrinoEmitter;
        HitPoints = Constants.AClassShipHullHitPoints;
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