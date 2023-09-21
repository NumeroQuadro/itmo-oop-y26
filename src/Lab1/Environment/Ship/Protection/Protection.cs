namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Protection;

public abstract class Protection
{
    private readonly ProtectionType _protectionType;

    protected Protection(ProtectionType protectionType)
    {
        _protectionType = protectionType;
    }

    protected uint AsteroidCounter { get; set; }
    protected uint MeteorCounter { get; set; }

    protected abstract void AssignNumericalConstantCharacteristics(ProtectionType protectionType);
    protected void DecrementAsteroidCounter()
    {
        if (IsProtectionActive())
        {
            --AsteroidCounter;
        }
    }

    protected void DecrementMeteorCounter()
    {
        if (IsProtectionActive())
        {
            --MeteorCounter;
        }
    }

    protected bool IsProtectionActive()
    {
        return MeteorCounter != 0 & AsteroidCounter != 0;
    }
}