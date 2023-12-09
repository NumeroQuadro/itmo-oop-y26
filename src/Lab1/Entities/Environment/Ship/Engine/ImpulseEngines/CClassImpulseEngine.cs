namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.Engine.ImpulseEngines;

public class CClassImpulseEngine : IImpulseEngine
{
    private const double CClassImpulseEngineVelocity = 45.0;
    private const double CClassImpulseEngineStartFuelConsumption = 10.0;
    private static double GetWastedFuelForStartBySpecialFormula => CClassImpulseEngineStartFuelConsumption;

    public double GetWastedFuelBySpecialFormula(double astronomicalUnitsTraveled)
    {
        return astronomicalUnitsTraveled + GetWastedFuelForStartBySpecialFormula;
    }

    public double GetWastedTimeBySpecialFormula(double astronomicalUnitsTraveled)
    {
        return astronomicalUnitsTraveled / CClassImpulseEngineVelocity;
    }
}