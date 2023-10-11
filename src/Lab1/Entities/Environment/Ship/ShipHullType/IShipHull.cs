using Itmo.ObjectOrientedProgramming.Lab1.Models.ProtectionState;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.ShipHullType;

public interface IShipHull
{
    public bool HasAntiNitrinoEmitter { get; }
    public double HitPoints { get; }
    public ProtectionState TakeDamage(double hitPoints);
}