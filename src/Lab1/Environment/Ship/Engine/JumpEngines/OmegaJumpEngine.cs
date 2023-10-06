using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Engine.JumpEngines;

public class OmegaJumpEngine : IJumpEngine
{
    public double MaxLength => 20;
    public double WastedGravitonFuel { get; private set; }

    public EngineState BurnFuel(double astronomicalUnitsTraveled)
    {
        double amountOfBurnedFuel = astronomicalUnitsTraveled * Math.Log(astronomicalUnitsTraveled);

        WastedGravitonFuel += amountOfBurnedFuel;

        return new EngineIsWorking();
    }

    public double GetTravelTime(double astronomicalUnitsTraveled)
    {
        return astronomicalUnitsTraveled / Constants.OmegaJumpEngineVelocity;
    }

    public EngineState StartEngine()
    {
        WastedGravitonFuel += Constants.JumpEngineStartFuelConsumption;

        return new EngineIsWorking();
    }
}