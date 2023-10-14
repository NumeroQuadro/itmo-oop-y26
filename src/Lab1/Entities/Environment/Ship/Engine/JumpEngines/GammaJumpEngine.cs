using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.Engine.JumpEngines;

public class GammaJumpEngine : IJumpEngine
{
    public double MaxLength => 30;

    public double GetWastedFuelBySpecialFormula(double astronomicalUnitsTraveled)
    {
        double amountOfBurnedFuel = astronomicalUnitsTraveled * astronomicalUnitsTraveled;

        return amountOfBurnedFuel;
    }

    public double GetWastedTimeBySpecialFormula(double astronomicalUnitsTraveled)
    {
        return astronomicalUnitsTraveled / Constants.GammaJumpEngineVelocity;
    }

    public double GetWastedFuelForStartBySpecialFormula()
    {
        return Constants.JumpEngineStartFuelConsumption;
    }
}