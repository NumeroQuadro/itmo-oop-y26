namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Engine;

public interface IEngine
{
    public EngineState BurnFuel(double astronomicalUnitsTraveled);
    public EngineState StartEngine();
    public double GetTravelTime(double astronomicalUnitsTraveled);
}