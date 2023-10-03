using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.DeflectorType;

public class BClassDeflector : IDeflector
{
    public BClassDeflector(bool hasPhotonModification)
    {
        HasPhotonModification = hasPhotonModification;

        HitPoints = HasPhotonModification ? Constants.BClassDeflectorWithPhotonModificationHitPoints : Constants.BClassDeflectorWithoutPhotonModificationHitPoints;
    }

    public bool HasPhotonModification { get; }
    public double HitPoints { get; private set; }

    public SpaceTravelResult? TakeDamage(double hitPoints)
    {
        if (HitPoints >= 0)
        {
            HitPoints -= hitPoints;
            return null;
        }

        return new ShuttleIsDestroyed();
    }
}