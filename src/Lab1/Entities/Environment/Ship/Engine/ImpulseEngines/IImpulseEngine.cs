using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.Engine.JumpEngines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.Engine.ImpulseEngines;

public interface IImpulseEngine : IEngine
{
    public double GetWastedFuelBySpecialFormula(double astronomicalUnitsTraveled);
}