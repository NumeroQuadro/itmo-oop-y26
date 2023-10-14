namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.EnvironmentTypes;

public interface ISpace : IEnvironment
{
    public void AddAsteroids(int numberOfAsteroids);
    public void AddMeteors(int numberOfMeteors);
}