namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.EnvironmentTypes;

public interface ISpace : IEnvironment
{
    public void AddAsteroids(uint numberOfAsteroids);
    public void AddMeteors(uint numberOfMeteors);
}