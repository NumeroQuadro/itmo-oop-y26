namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Protection;

public abstract class Protection
{
    private readonly ProtectionType _protectionType;

    protected Protection(ProtectionType protectionType, uint asteroidCounter, uint meteorCounter, uint spaceWhaleCounter)
    {
        _protectionType = protectionType;

        AsteroidCounter = asteroidCounter;
        MeteorCounter = meteorCounter;
    }

    private uint AsteroidCounter { get; set; }
    private uint MeteorCounter { get; set; }
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