using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Engine.ImpulseEngines;

public class EClassImpulseEngine : IEngine
{
    public double WasteFuel { get; private set; }

    public EngineState BurnFuel(double kilometersTraveled)
    {
        double amountOfBurnedFuel = Math.Exp(kilometersTraveled);

        WasteFuel += amountOfBurnedFuel;

        return new EngineIsWorking();
    }

    public double GetTravelTime(double kilometersTraveled)
    {
        return kilometersTraveled / Constants.EClassImpulseEngineVelocity;
    }

    public EngineState StartEngine()
    {
        WasteFuel += Constants.EClassImpulseEngineStartFuelConsumption;

        return new EngineIsWorking();
    }
}