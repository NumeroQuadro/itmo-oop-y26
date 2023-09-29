using Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Protection;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Protection.ProtectionConditions;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Protection.ProtectionTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship;

public class Deflector
{
    private readonly MeteoroidProtectionType _protectionType;

    public Deflector(MeteoroidProtectionType protectionType, bool hasPhotonModification)
    {
        _protectionType = protectionType;
        HasPhotonModification = hasPhotonModification;
        
        AssignCounters();

        IsDestroyed = false;
        CalculateHitPoints();
    }

    public bool HasPhotonModification { get; private set; }
    public bool IsDestroyed { get; private set; }
    public uint HitPoints { get; private set; }
    public uint MaxAsteroidCounter { get; private set; }
    public uint MaxMeteorCounter { get; private set; }

    public void TakeDamage(uint hitPoints)
    {
        if (hitPoints >= HitPoints)
        {
            IsDestroyed = true;
        }
    }
    private void CalculateHitPoints()
    {
        HitPoints = MaxAsteroidCounter * MaxMeteorCounter;
    }

    private void AssignCounters()
    {
        MaxAsteroidCounter = 4;
        MaxMeteorCounter = 5;
    }
}