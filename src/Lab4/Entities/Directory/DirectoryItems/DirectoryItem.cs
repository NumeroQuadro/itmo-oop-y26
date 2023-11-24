using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.AppStateInformation.AppStateInitial;

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

    public IEnumerable<IFileSystemItem> GetFilesInCurrentDirectory(FileSystemContext context)
    {
        return new[] { this };
    }

    public IEnumerable<string> GetDisplayableItem(FileSystemContext context, int treeDepth)
    {
        string result;
        if (context.TreeListWritingOptions is null)
        {
            result = " " + "file: ";
        }
        else
        {
            result = string.Join(context.TreeListWritingOptions.Indentation, treeDepth) + context.TreeListWritingOptions.FilePrefix;
        }

        return new[] { result };
    }
}