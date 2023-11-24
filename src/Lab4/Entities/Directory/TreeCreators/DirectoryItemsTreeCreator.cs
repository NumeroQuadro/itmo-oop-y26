using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.AppStateInformation.AppStateInitial;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Directory.DirectoryTreeCreators;

public class DirectoryItemsTreeCreator : IDirectoryItemsTreeCreator
{
    public TreeCreationResult Create(FileSystemContext context, IDirectory? currentPathDirectory)
    {
        if (currentPathDirectory is null)
        {
            return new TreeCreationResult.TreeCreationFailed("Directory is null");
        }

        IEnumerable<IFileSystemItem> items = currentPathDirectory.GetFilesInCurrentDirectory(context);
        var writer = new ConsoleTreeWriter();

        foreach (IFileSystemItem item in items)
        {
            IEnumerable<string> results = item.GetDisplayableItem(context, 1);
            writer.DisplayTreeItem(results);
        }

        return new TreeCreationResult.TreeCreatedSuccessfully();
    }
}