using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.ProtectionState;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.DeflectorType;

public class BClassDeflector : IDeflector
{
    public BClassDeflector(bool hasPhotonModification)
    {
        HasPhotonModification = hasPhotonModification;
        HitPoints = Constants.BClassDeflectorHitPoints;
    }

    public bool HasPhotonModification { get; }
    public double HitPoints { get; private set; }

    public ProtectionState.ProtectionState TakeDamage(double hitPoints)
    {
        if (HitPoints > 0)
        {
            HitPoints -= hitPoints;
            return new ProtectionIsEnabled();
        }

        return new ImpossibleToBeDamaged();
    }
}