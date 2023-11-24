namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Directory.DirectoryItems;

public interface IDirectoryItem
{
    public IDirectory? ParentDirectory { get; }
    public string Path { get; }
}