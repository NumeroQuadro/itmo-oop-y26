namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Engine.ImpulseEngines;

public class CClassImpulseEngine : IImpulseEngine
{
    public double MaxLength => 1000;
    public double WastedFuel { get; private set; }

    public EngineState BurnFuel(double astronomicalUnitsTraveled)
    {
        WastedFuel += astronomicalUnitsTraveled;

        return new EngineIsWorking();
    }

    public double GetTravelTime(double astronomicalUnitsTraveled)
    {
        return astronomicalUnitsTraveled / Constants.CClassImpulseEngineVelocity;
    }

    public EngineState StartEngine()
    {
        WastedFuel += Constants.CClassImpulseEngineStartFuelConsumption;

        return new EngineIsWorking();
    }
}