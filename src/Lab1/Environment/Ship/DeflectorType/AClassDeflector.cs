using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.DeflectorType;

public class AClassDeflector : IDeflector
{
    public AClassDeflector(bool hasPhotonModification)
    {
        HasPhotonModification = hasPhotonModification;

        HitPoints = HasPhotonModification ? Constants.AClassDeflectorWithPhotonModificationHitPoints : Constants.AClassDeflectorWithoutPhotonModificationHitPoints;
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