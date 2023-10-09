using System;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Engine.ImpulseEngines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.Engine.ImpulseEngines;

public class EClassImpulseEngine : IImpulseEngine
{
    public double MaxLength => 500;
    public double WastedFuel { get; private set; }

    public EngineState BurnFuel(double astronomicalUnitsTraveled)
    {
        double amountOfBurnedFuel = Math.Exp(astronomicalUnitsTraveled);

        WastedFuel += amountOfBurnedFuel;

        return new EngineIsWorking();
    }

    public double GetTravelTime(double astronomicalUnitsTraveled)
    {
        return Math.Log(astronomicalUnitsTraveled + 1);
    }

    public EngineState StartEngine()
    {
        WastedFuel += Constants.EClassImpulseEngineStartFuelConsumption;

        return new EngineIsWorking();
    }
}