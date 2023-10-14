using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.Engine.ImpulseEngines;

public class EClassImpulseEngine : IImpulseEngine
{
    public double GetWastedFuelBySpecialFormula(double astronomicalUnitsTraveled)
    {
        return Math.Exp(astronomicalUnitsTraveled) + GetWastedFuelForStartBySpecialFormula();
    }

    public double GetWastedTimeBySpecialFormula(double astronomicalUnitsTraveled)
    {
        return Math.Log(astronomicalUnitsTraveled + 1);
    }

    private static double GetWastedFuelForStartBySpecialFormula()
    {
        return Constants.EClassImpulseEngineStartFuelConsumption;
    }
}