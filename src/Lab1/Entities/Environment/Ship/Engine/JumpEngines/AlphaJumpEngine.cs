namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Engine.JumpEngines;

public class AlphaJumpEngine : IJumpEngine
{
    public double MaxLength => 10;
    public double WastedGravitonFuel { get; private set; }

    public EngineState BurnFuel(double astronomicalUnitsTraveled)
    {
        WastedGravitonFuel += astronomicalUnitsTraveled;

        return new EngineIsWorking();
    }

    public double GetTravelTime(double astronomicalUnitsTraveled)
    {
        return astronomicalUnitsTraveled / Constants.AlphaJumpEngineVelocity;
    }

    public EngineState StartEngine()
    {
        WastedGravitonFuel += Constants.JumpEngineStartFuelConsumption;

        return new EngineIsWorking();
    }
}