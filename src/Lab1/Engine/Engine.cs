namespace Itmo.ObjectOrientedProgramming.Lab1.Engine;

public class Engine
{
    public uint FuelConsumptionPerOneAstronomicalUnit { get; init; }
    public uint CurrentFuelLevel { get; private set; }
    public uint FuelWasteStart { get; init; }
    public uint MaximalSpeed { get; init; }
    public EngineClass EngineClass { get; init; }

    public void WasteFuelForTransportation(uint astronomicalUnits)
    {
        CurrentFuelLevel -= astronomicalUnits * FuelConsumptionPerOneAstronomicalUnit;
    }

    public void StartEngine()
    {
        CurrentFuelLevel -= FuelWasteStart;
    }

    public bool IsEngineHasFuel()
    {
        return CurrentFuelLevel != 0;
    }
}