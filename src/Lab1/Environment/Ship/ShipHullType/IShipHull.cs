using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.ShipHullType;

public interface IShipHull
{
    public bool HasAntiNitrinoEmitter { get; }
    public double HitPoints { get; }
    public SpaceTravelResult? TakeDamage(double hitPoints);
}