using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Protection.ProtectionConditions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.DamageHandler;

public class DamageHandler
{
    private DamageHandler? _nextDamageHandler;

    public DamageHandler SetNextDamageHandler(DamageHandler damageHandler)
    {
        _nextDamageHandler = damageHandler;
        return damageHandler;
    }

    public virtual ProtectionCondition? DealDamage(double hitPoints)
    {
        return _nextDamageHandler?.DealDamage(hitPoints);
    }
}