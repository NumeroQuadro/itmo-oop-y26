namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.Engine.JumpEngines;

public class AlphaJumpEngine : IJumpEngine
{
    private const double JumpEngineStartFuelConsumption = 20.0;
    private const double AlphaJumpEngineVelocity = 100;

    private readonly double _maxLength = 10;
    private static double GetWastedFuelForStartBySpecialFormula => JumpEngineStartFuelConsumption;

    public double GetWastedFuelBySpecialFormula(double astronomicalUnitsTraveled)
    {
        return astronomicalUnitsTraveled;
    }

    public double GetWastedTimeBySpecialFormula(double astronomicalUnitsTraveled)
    {
        return (astronomicalUnitsTraveled / AlphaJumpEngineVelocity) + GetWastedFuelForStartBySpecialFormula;
    }

    public bool IsEnoughLengthToFly(double environmentLength)
    {
        return environmentLength < _maxLength;
    }
}