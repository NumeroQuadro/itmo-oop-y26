namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.ShipHullType;

public interface IShipHull
{
    public bool HasAntiNitrinoEmitter { get; }
    public double HitPoints { get; }
    public ProtectionState.ProtectionState TakeDamage(double hitPoints);
}