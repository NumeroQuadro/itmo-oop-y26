using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.Engine.ImpulseEngines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class ImpulseEngineWorkingTime : IMesuarableObject<IImpulseEngine>
{
    public double PricePerOneMesuarableValue => 1;
    public double Cost => PricePerOneMesuarableValue * AmountOfMesuarableValue;
    public double AmountOfMesuarableValue { get; private set; }

    public void CalculateAndIncreaseMesurableValue(IImpulseEngine t, double influencingValue)
    {
        AmountOfMesuarableValue += t.GetWastedTimeBySpecialFormula(influencingValue);
    }

    public void AddAmountOfMeasurableValue(double amount)
    {
        AmountOfMesuarableValue += amount;
    }
}