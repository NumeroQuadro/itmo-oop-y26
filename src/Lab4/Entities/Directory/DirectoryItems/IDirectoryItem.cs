namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Directory.DirectoryItems;

public interface IDirectoryItem : IFileSystemItem
{
    public IDirectory? ParentDirectory { get; }
    public string Path { get; }
}