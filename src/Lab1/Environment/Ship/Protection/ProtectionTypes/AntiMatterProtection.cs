using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Protection.ProtectionConditions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Protection.ProtectionTypes;

public class AntiMatterProtection : Protection
{
    private uint AntiMatterCounter { get; set; } = 2;

    public override void TakeDamage()
    {
        --AntiMatterCounter;
    }

    public override ProtectionCondition ProtectionCondition()
    {
        if (AntiMatterCounter != 0)
        {
            return new IsWorking();
        }

        return new IsDestroyed();
    }
}