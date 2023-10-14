namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.Engine.JumpEngines;

public interface IJumpEngine : IEngine
{
    public double GetWastedFuelBySpecialFormula(double astronomicalUnitsTraveled);
}