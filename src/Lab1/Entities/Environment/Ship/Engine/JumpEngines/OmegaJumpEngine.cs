using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.Engine.JumpEngines;

public class OmegaJumpEngine : IJumpEngine, IFuelUsage, ITimeUsage
{
    private readonly double _maxLength = 20;

    public double GetWastedFuelBySpecialFormula(double astronomicalUnitsTraveled)
    {
        double amountOfBurnedFuel = astronomicalUnitsTraveled * Math.Log(astronomicalUnitsTraveled);

        return amountOfBurnedFuel;
    }

    public double GetWastedTimeBySpecialFormula(double astronomicalUnitsTraveled)
    {
        return astronomicalUnitsTraveled / Constants.OmegaJumpEngineVelocity;
    }

    public double GetWastedFuelForStartBySpecialFormula()
    {
        return Constants.JumpEngineStartFuelConsumption;
    }

    public bool IsEnoughLengthToFly(double environmentLength)
    {
        return environmentLength < _maxLength;
    }
}