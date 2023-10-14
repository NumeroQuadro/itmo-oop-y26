namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.Engine.JumpEngines;

public interface IJumpEngine : IFuelUsage, ITimeUsage
{
    public bool IsEnoughLengthToFly(double environmentLength);
}