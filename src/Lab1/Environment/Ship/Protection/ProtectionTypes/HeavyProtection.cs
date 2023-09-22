using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Protection.ProtectionConditions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Protection.ProtectionTypes;

public class HeavyProtection : Protection
{
    private bool _isDisabled;
    public HeavyProtection(bool isDisabled)
    {
        _isDisabled = isDisabled;
        MeteorCounter = 2;
    }

    private uint MeteorCounter { get; set; }

    public override void TakeDamage()
    {
        --MeteorCounter;
    }

    public override ProtectionCondition ProtectionCondition()
    {
        if (_isDisabled)
        {
            return new IsDisabled();
        }
        else if (MeteorCounter != 0)
        {
            return new IsWorking();
        }

        return new IsDestroyed();
    }
}