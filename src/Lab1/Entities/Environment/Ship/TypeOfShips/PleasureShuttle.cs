using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.ShipHullType;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.DeflectorType;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Engine.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Engine.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.TypeOfShips;

public class PleasureShuttle : ISpaceShuttle
{
    public IImpulseEngine ImpulseEngine { get; } = new CClassImpulseEngine();
    public IJumpEngine? JumpEngine => null;
    public IShipHull ShipHull { get; } = new BClassShipHull(false);
    public IDeflector? Deflector => null;
}