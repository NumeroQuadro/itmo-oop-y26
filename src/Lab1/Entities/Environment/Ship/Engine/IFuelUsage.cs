namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.Engine;

public interface IFuelUsage
{
    public double GetWastedFuelBySpecialFormula(double astronomicalUnitsTraveled);
    public double GetWastedFuelForStartBySpecialFormula();
}