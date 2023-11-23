namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Directory;

public interface IDirectory
{
    public string StringDirectoryPath { get; }
    public string GetDirectoryDependingOnSystem(string path);
}