using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Engine.JumpEngines;

public class OmegaJumpEngine : IEngine
{
    public double WasteFuel { get; private set; }

    public EngineState BurnFuel(double kilometersTraveled)
    {
        double amountOfBurnedFuel = kilometersTraveled * Math.Log(kilometersTraveled);

        WasteFuel += amountOfBurnedFuel;

        return new EngineIsWorking();
    }

    public double GetTravelTime(double kilometersTraveled)
    {
        return kilometersTraveled / Constants.OmegaJumpEngineVelocity;
    }

    public EngineState StartEngine()
    {
        WasteFuel += Constants.JumpEngineStartFuelConsumption;

        return new EngineIsWorking();
    }
}