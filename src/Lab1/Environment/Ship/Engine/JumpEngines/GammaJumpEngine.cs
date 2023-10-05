namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Engine.JumpEngines;

public class GammaJumpEngine : IEngine
{
    public double WastedGravitonFuel { get; private set; }

    public EngineState BurnFuel(double astronomicalUnitsTraveled)
    {
        double amountOfBurnedFuel = astronomicalUnitsTraveled * astronomicalUnitsTraveled;

        WastedGravitonFuel += amountOfBurnedFuel;

        return new EngineIsWorking();
    }

    public double GetTravelTime(double astronomicalUnitsTraveled)
    {
        return astronomicalUnitsTraveled / Constants.GammaJumpEngineVelocity;
    }

    public EngineState StartEngine()
    {
        WastedGravitonFuel += Constants.JumpEngineStartFuelConsumption;

        return new EngineIsWorking();
    }
}