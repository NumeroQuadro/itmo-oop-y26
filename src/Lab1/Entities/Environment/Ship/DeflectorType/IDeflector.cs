using Itmo.ObjectOrientedProgramming.Lab1.Models.ProtectionState;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.DeflectorType;

public interface IDeflector
{
    public bool HasPhotonModification { get; }
    public double HitPoints { get; }
    public double SpecialHitPoints { get; }
    public ProtectionState TakeDamage(double hitPoints);
    public ProtectionState TakeSpecialDamage(double hitPoints);
}