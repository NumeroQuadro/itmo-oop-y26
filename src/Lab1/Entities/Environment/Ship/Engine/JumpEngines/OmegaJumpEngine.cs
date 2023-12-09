using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.Engine.JumpEngines;

public class OmegaJumpEngine : IJumpEngine
{
    private const double OmegaJumpEngineVelocity = 200;
    private const double JumpEngineStartFuelConsumption = 20.0;
    private readonly double _maxLength = 20;

    private static double GetWastedFuelForStartBySpecialFormula => JumpEngineStartFuelConsumption;

    public double GetWastedFuelBySpecialFormula(double astronomicalUnitsTraveled)
    {
        double amountOfBurnedFuel = astronomicalUnitsTraveled * Math.Log(astronomicalUnitsTraveled);

        return amountOfBurnedFuel;
    }

    public double GetWastedTimeBySpecialFormula(double astronomicalUnitsTraveled)
    {
        return (astronomicalUnitsTraveled / OmegaJumpEngineVelocity) + GetWastedFuelForStartBySpecialFormula;
    }

    public bool IsEnoughLengthToFly(double environmentLength)
    {
        return environmentLength < _maxLength;
    }
}