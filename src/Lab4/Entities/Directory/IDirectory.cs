namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Directory;

public interface IDirectory : IFileSystemItem
{
    public string StringDirectoryPath { get; }
    public string DirectoryDependingOnSystem { get; }
}