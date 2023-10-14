using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.Engine.ImpulseEngines;

public class CClassImpulseEngine : IImpulseEngine
{
    public double GetWastedFuelBySpecialFormula(double astronomicalUnitsTraveled)
    {
        return astronomicalUnitsTraveled + GetWastedFuelForStartBySpecialFormula();
    }

    public double GetWastedTimeBySpecialFormula(double astronomicalUnitsTraveled)
    {
        return astronomicalUnitsTraveled / Constants.CClassImpulseEngineVelocity;
    }

    private static double GetWastedFuelForStartBySpecialFormula()
    {
        return Constants.CClassImpulseEngineStartFuelConsumption;
    }
}