using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.DeflectorType;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Engine.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Engine.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.ShipHullType;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;

public interface ISpaceShuttle : IMovement
{
    public IShipHull ShipHull { get; }
    public IDeflector? Deflector { get; }
    public IImpulseEngine? ImpulseEngine { get; }
    public IJumpEngine? JumpEngine { get; }
    public SpaceTravelResult? TakeDamageAndGetResult(double hitPoints);
    public SpaceTravelResult? TakeSpecialDamageAndGetResult(double hitPoints);
}