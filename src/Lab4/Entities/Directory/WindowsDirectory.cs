using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Directory;

public class WindowsDirectory : IDirectory
{
    private readonly string _currentPath;
    private IDirectory? _parentDirectory;

    public WindowsDirectory(string initialPath)
    {
        _currentPath = initialPath;
    }

    public string StringDirectoryPath => _currentPath;

    public string GetDirectoryDependingOnSystem(string path)
    {
        return Path.GetFullPath(path);
    }

    public void WithParentDirectory(IDirectory parentDirectory)
    {
        _parentDirectory = parentDirectory;
    }
}