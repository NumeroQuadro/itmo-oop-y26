using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.ShipHullType;

public class NitrinoEmmiter : INitrinoEmmiter
{
    private readonly IShipHull _shipHullType;

    public NitrinoEmmiter(IShipHull shipHullType)
    {
        if (_shipHullType != null) HitPoints = _shipHullType.HitPoints;
        _shipHullType = shipHullType;
    }

    public double HitPoints { get; }

    public ProtectionState TakeDamage(double hitPoints)
    {
        return new ProtectionState.ProtectionIsEnabled();
    }
}