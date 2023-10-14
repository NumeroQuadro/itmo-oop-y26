using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.ProtectionState;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.DeflectorType;

public class BClassDeflector : IDeflector
{
    public BClassDeflector(bool hasPhotonModification)
    {
        HasPhotonModification = hasPhotonModification;
        HitPoints = Constants.BClassDeflectorHitPoints;
        SpecialHitPoints = Constants.BClassDeflectorHitPoints;
    }

    public bool HasPhotonModification { get; }
    public double HitPoints { get; private set; }
    public double SpecialHitPoints { get; private set; }

    public ProtectionState TakeDamage(double hitPoints)
    {
        if (HitPoints > 0)
        {
            HitPoints -= hitPoints;

            return new ProtectionIsEnabled();
        }

        return new ImpossibleToBeDamaged();
    }

    public ProtectionState TakeSpecialDamage(double hitPoints)
    {
        if (SpecialHitPoints > 0)
        {
            SpecialHitPoints -= Constants.BClassDeflectorDustingAntiMatterDamageReduceCoefficient * hitPoints;

            return new ProtectionIsEnabled();
        }

        return new ImpossibleToBeDamaged();
    }
}