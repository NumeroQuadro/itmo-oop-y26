using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Engine.JumpEngines;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class JumpEngineWorkingTime : IMesuarableObject<IJumpEngine>
{
    public double PricePerOneMesuarableValue => 1;
    public double Cost => PricePerOneMesuarableValue * AmountOfMesuarableValue;
    public double AmountOfMesuarableValue { get; private set; }

    public void CalculateAndIncreaseMesurableValue(IJumpEngine t, double influencingValue)
    {
        AmountOfMesuarableValue += t.GetWastedTimeBySpecialFormula(influencingValue);
    }

    public void AddAmountOfMeasurableValue(double amount)
    {
        AmountOfMesuarableValue += amount;
    }
}