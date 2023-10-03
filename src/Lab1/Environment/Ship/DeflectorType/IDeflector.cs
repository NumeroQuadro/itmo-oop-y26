namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.DeflectorType;

public interface IDeflector
{
    public bool HasPhotonModification { get; }
    public double HitPoints { get; }
    public ProtectionState.ProtectionState TakeDamage(double hitPoints);
}