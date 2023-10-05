using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.ShipHullType;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;

public interface ISpaceShuttle : IMovement
{
    public IShipHull ShipHull { get; }
    public SpaceTravelResult? TakeDamageAndGetResult(double hitPoints);
    public SpaceTravelResult? TakeSpecialDamageAndGetResult(double hitPoints);
}