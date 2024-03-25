namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.Engine.JumpEngines;

public class GammaJumpEngine : IJumpEngine
{
    private const double GammaJumpEngineVelocity = 300;
    private const double JumpEngineStartFuelConsumption = 20.0;
    private readonly double _maxLength = 30;
    private static double GetWastedFuelForStartBySpecialFormula => JumpEngineStartFuelConsumption;

    public double GetWastedFuelBySpecialFormula(double astronomicalUnitsTraveled)
    {
        double amountOfBurnedFuel = astronomicalUnitsTraveled * astronomicalUnitsTraveled;

        return amountOfBurnedFuel;
    }

    public double GetWastedTimeBySpecialFormula(double astronomicalUnitsTraveled)
    {
        return (astronomicalUnitsTraveled / GammaJumpEngineVelocity) + GetWastedFuelForStartBySpecialFormula;
    }

    public bool IsEnoughLengthToFly(double environmentLength)
    {
        return environmentLength < _maxLength;
    }
}