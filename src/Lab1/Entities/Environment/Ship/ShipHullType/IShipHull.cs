using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.ShipHullType;

public interface IShipHull
{
    public double HitPoints { get; }
    public ProtectionState TakeDamage(double hitPoints);
}