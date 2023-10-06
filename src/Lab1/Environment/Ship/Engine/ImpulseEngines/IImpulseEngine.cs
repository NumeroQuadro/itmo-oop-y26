namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Engine.ImpulseEngines;

public interface IImpulseEngine
{
    public double MaxLength { get; }
    public double WastedFuel { get; }
    public EngineState BurnFuel(double astronomicalUnitsTraveled);
    public EngineState StartEngine();
    public double GetTravelTime(double astronomicalUnitsTraveled);
}