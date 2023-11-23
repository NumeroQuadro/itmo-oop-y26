namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Directory;

public class StringViewDirectory : IDirectory
{
    private readonly string _currentPath;

    public StringViewDirectory(string initialPath)
    {
        _currentPath = initialPath;
    }

    public string StringDirectoryPath => _currentPath;

    public string GetDirectoryDependingOnSystem(string path)
    {
        return path;
    }
}