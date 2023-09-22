using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Engine.JumpEngines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Engine;

public class Engine
{
    public Engine(EngineImpulseType engineImpulseType, EngineJumpType engineJumpType)
    {
        EngineImpulseType = engineImpulseType;
        EngineJumpType = engineJumpType;
    }

    public uint FuelConsumptionPerOneAstronomicalUnit { get; init; }
    public uint CurrentFuelLevel { get; private set; }
    public uint FuelWasteStart { get; init; }
    public uint MaximalSpeed { get; init; }
    public EngineImpulseType EngineImpulseType { get; init; }
    public EngineJumpType EngineJumpType { get; init; }

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