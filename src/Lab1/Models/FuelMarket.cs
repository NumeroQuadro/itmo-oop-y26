namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class FuelMarket
{
    private double _amountOfActivePlasma;
    private double _amountOfGravitonFuel;
    private double _activePlasmaCost = 23;
    private double _gravitonFuelCost = 56;

    public FuelMarket()
    {
        _amountOfGravitonFuel = 0;
        _amountOfActivePlasma = 0;
    }

    public double GetCost => (_amountOfActivePlasma * _activePlasmaCost) + (_amountOfGravitonFuel * _gravitonFuelCost);

    public void IncreaseAmountOfGravitonFuel(double amount)
    {
        _amountOfGravitonFuel += amount;
    }

    public void IncreaseAmountOfActivePlasma(double amount)
    {
        _amountOfActivePlasma += amount;
    }
}