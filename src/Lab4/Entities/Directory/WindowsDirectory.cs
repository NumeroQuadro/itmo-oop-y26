using System.Collections.Generic;
using System.IO;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.AppStateInformation.AppStateInitial;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Directory.DirectoryItems;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.InformationConverter;

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

    public string DirectoryDependingOnSystem => Path.GetFullPath(_currentPath);

    public IEnumerable<IFileSystemItem> GetFilesInCurrentDirectory(FileSystemContext context)
    {
        var directoryItems = GetDirectoryItems(_currentPath).ToList();
        List<DirectoryItem> items = new();

        foreach (string item in directoryItems)
        {
            var directoryItem = new DirectoryItem(item);
            directoryItem.WithParentDirectory(new WindowsDirectory(_currentPath));
            items.Add(directoryItem);
        }

        return items;
    }

    public IEnumerable<string> GetDisplayableItem(FileSystemContext context, int treeDepth)
    {
        List<string> result = new();

        var subdirectoriyStrings = GetSubDirectories(_currentPath).ToList();
        var filesStrings = GetDirectoryItems(_currentPath).ToList();
        IEnumerable<DirectoryItem> filesItems = filesStrings.Select(x => new DirectoryItem(x));
        var converter = new ConverterInfoRelatedToOperatingSystem(context);
        IEnumerable<IDirectory> subdirectories = subdirectoriyStrings.Select(x => converter.GetPathRelatedToSystem(x));

        foreach (DirectoryItem file in filesItems)
        {
            if (context.TreeListWritingOptions is null)
            {
                result.Add(" " + "dir: " + Path.GetFileName(file.Path));
            }
            else
            {
                result.Add((context.TreeListWritingOptions.Indentation, treeDepth) + context.TreeListWritingOptions.DirectoryPrefix + Path.GetFileName(file.Path));
            }
        }

        foreach (IDirectory subdirectory in subdirectories)
        {
            if (context.TreeListWritingOptions is null)
            {
                result.Add(" " + "dir: " + Path.GetFileName(subdirectory.StringDirectoryPath));
            }
            else
            {
                result.Add((context.TreeListWritingOptions.Indentation, treeDepth) + context.TreeListWritingOptions.DirectoryPrefix + Path.GetFileName(subdirectory.StringDirectoryPath));
            }
        }

        return result;
    }

    public void WithParentDirectory(IDirectory parentDirectory)
    {
        _parentDirectory = parentDirectory;
    }

    private static IEnumerable<string> GetDirectoryItems(string path)
    {
        return System.IO.Directory.GetFiles(path, "*");
    }

    private static IEnumerable<string> GetSubDirectories(string path)
    {
        return System.IO.Directory.GetDirectories(path, "*");
    }
}