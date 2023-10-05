using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.ProtectionState;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.DeflectorType;

public class AClassDeflector : IDeflector
{
    public AClassDeflector(bool hasPhotonModification)
    {
        HasPhotonModification = hasPhotonModification;
        HitPoints = Constants.AClassDeflectorHitPoints;
        SpecialHitPoints = Constants.AClassDeflectorHitPoints;
    }

    public bool HasPhotonModification { get; }
    public double HitPoints { get; private set; }
    public double SpecialHitPoints { get; private set; }

    public ProtectionState.ProtectionState TakeDamage(double hitPoints)
    {
        if (hitPoints > HitPoints)
        {
            return new ProtectionIsNotAbsorbAllDamage(hitPoints - HitPoints);
        }

        if (HitPoints > 0)
        {
            HitPoints -= hitPoints;

            return new ProtectionIsEnabled();
        }

        return new ImpossibleToBeDamaged();
    }

    public ProtectionState.ProtectionState TakeSpecialDamage(double hitPoints)
    {
        if (SpecialHitPoints > 0)
        {
            SpecialHitPoints -= Constants.AClassDeflectorDustingAntiMatterDamageReduceCoefficient * hitPoints;

            return new ProtectionIsEnabled();
        }

        return new ImpossibleToBeDamaged();
    }
}