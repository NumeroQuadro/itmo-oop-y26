using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.DeflectorType;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.Engine.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.Engine.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.ShipHullType;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.SpaceMovement;

public interface ISpaceShuttle
{
    public IShipHull ShipHull { get; }
    public IDeflector? Deflector { get; }
    public IImpulseEngine? ImpulseEngine { get; }
    public IJumpEngine? JumpEngine { get; }
}