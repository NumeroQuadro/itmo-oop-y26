using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.Engine.JumpEngines;

public class OmegaJumpEngine : IJumpEngine
{
    private readonly double _maxLength = 20;

    public double GetWastedFuelBySpecialFormula(double astronomicalUnitsTraveled)
    {
        double amountOfBurnedFuel = astronomicalUnitsTraveled * Math.Log(astronomicalUnitsTraveled);

        return amountOfBurnedFuel;
    }

    public double GetWastedTimeBySpecialFormula(double astronomicalUnitsTraveled)
    {
        return (astronomicalUnitsTraveled / Constants.OmegaJumpEngineVelocity) + GetWastedFuelForStartBySpecialFormula();
    }

    public bool IsEnoughLengthToFly(double environmentLength)
    {
        return environmentLength < _maxLength;
    }

    private static double GetWastedFuelForStartBySpecialFormula()
    {
        return Constants.JumpEngineStartFuelConsumption;
    }
}