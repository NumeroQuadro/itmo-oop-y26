using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Protection.ProtectionConditions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Protection.ProtectionTypes;

public sealed class LightProtection : Protection
{
    private uint AsteroidCounter { get; set; } = 2;

    public override void TakeDamage()
    {
        --AsteroidCounter;
    }

    public override ProtectionCondition ProtectionCondition()
    {
        if (AsteroidCounter != 0)
        {
            return new IsWorking();
        }

        return new IsDestroyed();
    }
}