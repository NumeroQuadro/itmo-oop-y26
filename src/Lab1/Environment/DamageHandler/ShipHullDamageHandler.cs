using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Protection;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Protection.ProtectionConditions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.DamageHandler;

public class ShipHullDamageHandler : DamageHandler
{
    private double _shipHullHitPoints;

    public ShipHullDamageHandler(double hitPoints)
    {
        _shipHullHitPoints = hitPoints;
    }

    public override ProtectionCondition? DealDamage(double hitPoints)
    {
        if (hitPoints > _shipHullHitPoints || _shipHullHitPoints <= 0)
        {
            return new IsDestroyed();
        }

        _shipHullHitPoints -= hitPoints;
        return new IsWorking();
    }
}