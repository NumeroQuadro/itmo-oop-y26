namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Engine.ImpulseEngines;

public class CClassImpulseEngine : IEngine
{
    public double WasteFuel { get; private set; }

    public EngineState BurnFuel(double kilometersTraveled)
    {
        WasteFuel += kilometersTraveled;

        return new EngineIsWorking();
    }

    public double GetTravelTime(double kilometersTraveled)
    {
        return kilometersTraveled / Constants.CClassImpulseEngineVelocity;
    }

    public EngineState StartEngine()
    {
        WasteFuel += Constants.CClassImpulseEngineStartFuelConsumption;

        return new EngineIsWorking();
    }
}