using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.DeflectorType;

public class BClassDeflector : IDeflector
{
    private double _hitPonts = Constants.BClassDeflectorHitPoints;
    public ProtectionState TakeDamageAndGetResult(double hitPoints)
    {
        if (_hitPonts > 0)
        {
            _hitPonts -= hitPoints;

            return new ProtectionState.ProtectionIsEnabled();
        }

        return new ProtectionState.ImpossibleToBeDamaged();
    }
}