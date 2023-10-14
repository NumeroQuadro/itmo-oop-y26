using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.Engine.ImpulseEngines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class ActivePlasmaFuel : IMesuarableObject<IImpulseEngine>
{
    public double PricePerOneMesuarableValue => 23;
    public double Cost => PricePerOneMesuarableValue * AmountOfMesuarableValue;
    public double AmountOfMesuarableValue { get; private set; }

    public void CalculateAndIncreaseMesurableValue(IImpulseEngine t, double influencingValue)
    {
        AmountOfMesuarableValue += t.GetWastedFuelBySpecialFormula(influencingValue);
    }

    public void AddAmountOfMeasurableValue(double amount)
    {
        AmountOfMesuarableValue += amount;
    }
}