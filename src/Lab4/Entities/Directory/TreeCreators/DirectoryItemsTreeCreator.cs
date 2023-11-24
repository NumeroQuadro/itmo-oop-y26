using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.AppStateInformation.AppStateInitial;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Directory.DirectoryItems;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.InformationConverter;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Directory.DirectoryTreeCreators;

public class DirectoryItemsTreeCreator : IDirectoryItemsTreeCreator
{
    public TreeCreationResult Create(FileSystemContext context, IDirectory? currentPathDirectory)
    {
        if (currentPathDirectory is null)
        {
            return new TreeCreationResult.TreeCreationFailed("Current path directory is null");
        }

        var directoryItems = GetDirectoryItems(currentPathDirectory.StringDirectoryPath).ToList();
        List<DirectoryItem> items = new();
        var converter = new ConverterInfoRelatedToOperatingSystem(context);

        foreach (string item in directoryItems)
        {
            var directoryItem = new DirectoryItem(item);
            directoryItem.WithParentDirectory(converter.GetPathRelatedToSystem(currentPathDirectory.StringDirectoryPath));
            items.Add(directoryItem);
        }

        return new TreeCreationResult.TreeCreatedSuccessfully(items);
    }

    private static IEnumerable<string> GetDirectoryItems(string path)
    {
        return System.IO.Directory.GetFiles(path, "*");
    }
}