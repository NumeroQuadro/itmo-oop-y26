namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.Engine.JumpEngines;

public interface IJumpEngine : IFuelUsage
{
    public bool IsEnoughLengthToFly(double environmentLength);
}