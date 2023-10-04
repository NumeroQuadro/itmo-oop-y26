namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Engine.JumpEngines;

public class GammaJumpEngine : IEngine
{
    public double WasteFuel { get; private set; }

    public EngineState BurnFuel(double kilometersTraveled)
    {
        double amountOfBurnedFuel = kilometersTraveled * kilometersTraveled;

        WasteFuel += amountOfBurnedFuel;

        return new EngineIsWorking();
    }

    public double GetTravelTime(double kilometersTraveled)
    {
        return kilometersTraveled / Constants.GammaJumpEngineVelocity;
    }

    public EngineState StartEngine()
    {
        WasteFuel += Constants.JumpEngineStartFuelConsumption;

        return new EngineIsWorking();
    }
}