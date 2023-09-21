using Itmo.ObjectOrientedProgramming.Lab1.Asteroid;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Protection;

public class Deflector : Protection
{
    public Deflector(ProtectionType protectionType, bool hasPhotonModification)
        : base(protectionType)
    {
        HasPhotonModification = hasPhotonModification;
    }

    public bool HasPhotonModification { get; private set; }
    private uint AntiMatterCounter { get; set; }

    protected override void AssignNumericalConstantCharacteristics(ProtectionType protectionType)
    {
        if (protectionType == ProtectionType.NoProtection)
        {
            AntiMatterCounter = 1;
            AsteroidCounter = 1;
            MeteorCounter = 1;
        }
    }

    public void TakeDamage(ObstacleType obstacleType)
    {
        if (HasPossibleToBeDamage(obstacleType))
        {
            DecreaseDamageCounters(obstacleType);
        }
    }

    public bool HasPossibleToBeDamage(ObstacleType obstacleType)
    {
        if (obstacleType == ObstacleType.DustingOfAntiMatter)
        {
            return IsSpecialProtectionActive() & IsProtectionActive();
        }

        return IsProtectionActive();
    }

    private bool IsSpecialProtectionActive()
    {
        return AntiMatterCounter != 0;
    }

    private void DecrementAntiMatterCounter()
    {
        if (HasPhotonModification)
        {
            --AntiMatterCounter;
        }
    }

    private void DecreaseDamageCounters(ObstacleType obstacleType)
    {
        switch (obstacleType)
        {
            case ObstacleType.SmallAsteroid:
                DecrementAsteroidCounter();
                break;
            case ObstacleType.Meteor:
                DecrementMeteorCounter();
                break;
            default:
                DecrementAntiMatterCounter();
                break;
        }
    }
}