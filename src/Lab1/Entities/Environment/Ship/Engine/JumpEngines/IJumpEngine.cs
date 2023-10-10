namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Engine.JumpEngines;

public interface IJumpEngine : IEngine
{
    public double GetWastedFuelBySpecialFormula(double astronomicalUnitsTraveled);
}