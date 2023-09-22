using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Protection.ProtectionConditions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Protection;

public abstract class Protection
{
    public abstract void TakeDamage();

    public abstract ProtectionCondition ProtectionCondition();
}