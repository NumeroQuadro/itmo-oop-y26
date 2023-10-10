namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Engine.JumpEngines;

public interface IEngine
{
    public double MaxLength { get; }
    public double GetWastedTimeBySpecialFormula(double astronomicalUnitsTraveled);
    public double GetWastedFuelForStartBySpecialFormula();
}