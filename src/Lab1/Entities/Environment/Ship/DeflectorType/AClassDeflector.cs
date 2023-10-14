using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.DeflectorType;

public class AClassDeflector : IDeflector
{
    private double _hitPoints = Constants.AClassDeflectorHitPoints;

    public ProtectionState TakeDamageAndGetResult(double hitPoints)
    {
        if (_hitPoints > 0)
        {
            _hitPoints -= hitPoints;

            return new ProtectionState.ProtectionIsEnabled();
        }

        return new ProtectionState.ImpossibleToBeDamaged();
    }
}