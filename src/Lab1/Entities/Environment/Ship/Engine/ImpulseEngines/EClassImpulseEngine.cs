using System;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Engine.ImpulseEngines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.Engine.ImpulseEngines;

public class EClassImpulseEngine : IImpulseEngine
{
    public double MaxLength => 500;
    public double WastedFuel { get; private set; }

    public double GetWastedFuelBySpecialFormula(double astronomicalUnitsTraveled)
    {
        return Math.Exp(astronomicalUnitsTraveled);
    }

    public double GetWastedTimeBySpecialFormula(double astronomicalUnitsTraveled)
    {
        return Math.Log(astronomicalUnitsTraveled + 1);
    }

    public double GetWastedFuelForStartBySpecialFormula()
    {
        return Constants.EClassImpulseEngineStartFuelConsumption;
    }
}