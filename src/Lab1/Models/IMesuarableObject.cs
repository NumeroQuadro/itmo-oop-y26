namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public interface IMesuarableObject<T>
{
    public double PricePerOneMesuarableValue { get; }
    public double Cost { get; }
    public double AmountOfMesuarableValue { get; }
    public void CalculateAndIncreaseMesurableValue(T t, double influencingValue);
    public void AddAmountOfMeasurableValue(double amount);
}