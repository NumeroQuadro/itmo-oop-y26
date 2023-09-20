using Itmo.ObjectOrientedProgramming.Lab1.Asteroid;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Protection;

public class Deflector : Protection
{
    // field for spaceWhale
    public Deflector(ProtectionType protectionType, bool hasPhotonModification, uint asteroidCounter, uint meteorCounter, uint spaceWhaleCounter)
        : base(protectionType, asteroidCounter, meteorCounter, spaceWhaleCounter)
    {
        HasPhotonModification = hasPhotonModification;
    }

    public bool HasPhotonModification { get; private set; }

    private uint AntiMatterCounter { get; set; }

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