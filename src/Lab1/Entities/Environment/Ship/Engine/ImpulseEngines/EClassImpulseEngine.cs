using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.Engine.ImpulseEngines;

public class EClassImpulseEngine : IImpulseEngine
{
    private const double EClassImpulseEngineStartFuelConsumption = 15.0;
    private static double GetWastedFuelForStartBySpecialFormula => EClassImpulseEngineStartFuelConsumption;

    public double GetWastedFuelBySpecialFormula(double astronomicalUnitsTraveled)
    {
        return Math.Exp(astronomicalUnitsTraveled) + GetWastedFuelForStartBySpecialFormula;
    }

    public double GetWastedTimeBySpecialFormula(double astronomicalUnitsTraveled)
    {
        return Math.Log(astronomicalUnitsTraveled + 1);
    }
}