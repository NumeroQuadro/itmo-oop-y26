namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Directory.DirectoryItems;

public class DirectoryItem : IDirectoryItem
{
    private readonly string _path;
    private IDirectory? _parentDirectory;

    public DirectoryItem(string path)
    {
        _path = path;
    }

    public IDirectory? ParentDirectory => _parentDirectory;
    public string Path => _path;

    public void WithParentDirectory(IDirectory parentDirectory)
    {
        _parentDirectory = parentDirectory;
    }
}