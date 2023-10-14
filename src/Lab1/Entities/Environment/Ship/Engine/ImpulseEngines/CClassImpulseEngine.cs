using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.Engine.ImpulseEngines;

public class CClassImpulseEngine : IImpulseEngine, IFuelUsage, ITimeUsage
{
    public double GetWastedFuelBySpecialFormula(double astronomicalUnitsTraveled)
    {
        return astronomicalUnitsTraveled;
    }

    public double GetWastedTimeBySpecialFormula(double astronomicalUnitsTraveled)
    {
        return astronomicalUnitsTraveled / Constants.CClassImpulseEngineVelocity;
    }

    public double GetWastedFuelForStartBySpecialFormula()
    {
        return Constants.CClassImpulseEngineStartFuelConsumption;
    }
}