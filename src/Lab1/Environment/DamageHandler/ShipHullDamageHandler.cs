using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.DamageHandler;

public class ShipHullDamageHandler : DamageHandler
{
    private double _shipHullHitPoints;

    public ShipHullDamageHandler(double hitPoints)
    {
        _shipHullHitPoints = hitPoints;
    }

    public override SpaceTravelResult? DealDamage(double hitPoints)
    {
        if (hitPoints > _shipHullHitPoints || _shipHullHitPoints <= 0)
        {
            return new ShuttleIsDestroyed();
        }

        _shipHullHitPoints -= hitPoints;
        return null;
    }
}