using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.DeflectorType;

public class CClassDeflector : IDeflector
{
    public CClassDeflector(bool hasPhotonModification)
    {
        HasPhotonModification = hasPhotonModification;

        HitPoints = HasPhotonModification ? Constants.CClassDeflectorWithPhotonModificationHitPoints : Constants.CClassDeflectorWithoutPhotonModificationHitPoints;
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