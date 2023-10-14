using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.Engine.JumpEngines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class GravitonFuel : IMesuarableObject<IJumpEngine>
{
    public double PricePerOneMesuarableValue => 45;
    public double Cost => PricePerOneMesuarableValue * AmountOfMesuarableValue;
    public double AmountOfMesuarableValue { get; private set; }

    public void CalculateAndIncreaseMesurableValue(IJumpEngine t, double influencingValue)
    {
        AmountOfMesuarableValue += t.GetWastedFuelBySpecialFormula(influencingValue);
    }

    public void AddAmountOfMeasurableValue(double amount)
    {
        AmountOfMesuarableValue += amount;
    }
}