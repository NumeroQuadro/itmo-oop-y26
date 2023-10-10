using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.ProtectionState;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.ShipHullType;

public interface IShipHull
{
    public bool HasAntiNitrinoEmitter { get; }
    public double HitPoints { get; }
    public ProtectionState TakeDamage(double hitPoints);
}