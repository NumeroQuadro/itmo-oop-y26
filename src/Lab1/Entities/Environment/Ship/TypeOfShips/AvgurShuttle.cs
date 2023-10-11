using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.DeflectorType;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Engine.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Engine.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.ShipHullType;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.TypeOfShips;

public class AvgurShuttle : ISpaceShuttle
{
    public AvgurShuttle(bool hasPhotonDeflectors)
    {
        Deflector = new CClassDeflector(hasPhotonDeflectors);
    }

    public IJumpEngine JumpEngine { get; } = new AlphaJumpEngine();
    public IImpulseEngine ImpulseEngine { get; } = new EClassImpulseEngine();
    public IShipHull ShipHull { get; } = new CClassShipHull(false);
    public IDeflector Deflector { get; }
}