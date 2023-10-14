using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.DeflectorType;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.Engine.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.Engine.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.ShipHullType;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.SpaceMovement;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.TypeOfShips;

public class StellaShuttle : ISpaceShuttle
{
    public StellaShuttle(bool hasPhotonDeflectors)
    {
        Deflector = new CClassDeflector(hasPhotonDeflectors);
    }

    public IShipHull ShipHull { get; } = new AClassShipHull(false);
    public IImpulseEngine ImpulseEngine { get; } = new CClassImpulseEngine();
    public IJumpEngine JumpEngine { get; } = new OmegaJumpEngine();
    public IDeflector Deflector { get; init; }
}