using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.DeflectorType;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.Engine.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.Engine.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.ShipHullType;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.SpaceMovement;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.TypeOfShips;

public class MeredianShuttle : ISpaceShuttle
{
    public MeredianShuttle(bool hasPhotonDeflectors)
    {
        Deflector = new BClassDeflector(hasPhotonDeflectors);
    }

    public IShipHull ShipHull { get; } = new BClassShipHull(true);
    public IImpulseEngine ImpulseEngine { get; } = new EClassImpulseEngine();
    public IJumpEngine JumpEngine { get; } = new GammaJumpEngine();
    public IDeflector Deflector { get; init; }
}