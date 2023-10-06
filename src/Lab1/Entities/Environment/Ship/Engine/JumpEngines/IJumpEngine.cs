namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Engine.JumpEngines;

public interface IJumpEngine
{
    public double MaxLength { get; }
    public double WastedGravitonFuel { get; }
    public EngineState BurnFuel(double astronomicalUnitsTraveled);
    public EngineState StartEngine();
    public double GetTravelTime(double astronomicalUnitsTraveled);
}