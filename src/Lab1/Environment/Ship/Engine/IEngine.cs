namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Engine;

public interface IEngine
{
    public double WasteFuel { get; }
    public EngineState BurnFuel(double kilometersTraveled);
    public EngineState StartEngine();
    public double GetTravelTime(double kilometersTraveled);
}