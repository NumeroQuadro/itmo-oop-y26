namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.EnvironmentTypes;

public interface ISpace : IEnvironment
{
    public void AddAsteroids(uint numberOfAsteroids);
    public void AddMeteors(uint numberOfMeteors);
}