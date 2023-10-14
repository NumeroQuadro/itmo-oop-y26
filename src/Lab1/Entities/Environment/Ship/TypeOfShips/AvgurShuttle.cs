using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.DeflectorType;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.Engine.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.Engine.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.ShipHullType;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.SpaceMovement;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.TypeOfShips;

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