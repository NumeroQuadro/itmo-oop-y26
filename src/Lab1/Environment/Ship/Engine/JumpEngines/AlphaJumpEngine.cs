namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Engine.JumpEngines;

public class AlphaJumpEngine : IEngine
{
    public double WasteFuel { get; private set; }

    public EngineState BurnFuel(double kilometersTraveled)
    {
        WasteFuel += kilometersTraveled;

        return new EngineIsWorking();
    }

    public double GetTravelTime(double kilometersTraveled)
    {
        return kilometersTraveled / Constants.AlphaJumpEngineVelocity;
    }

    public EngineState StartEngine()
    {
        WasteFuel += Constants.JumpEngineStartFuelConsumption;

        return new EngineIsWorking();
    }
}