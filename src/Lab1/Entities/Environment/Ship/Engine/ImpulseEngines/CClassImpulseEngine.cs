namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Engine.ImpulseEngines;

public class CClassImpulseEngine : IImpulseEngine
{
    public double MaxLength => 1000;
    public double WastedFuel { get; private set; }

    public double GetWastedFuelBySpecialFormula(double astronomicalUnitsTraveled)
    {
        return astronomicalUnitsTraveled;
    }

    public double GetWastedTimeBySpecialFormula(double astronomicalUnitsTraveled)
    {
        return astronomicalUnitsTraveled / Constants.CClassImpulseEngineVelocity;
    }

    public double GetWastedFuelForStartBySpecialFormula()
    {
        return Constants.CClassImpulseEngineStartFuelConsumption;
    }
}