using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.AppStateInformation.AppStateInitial;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Directory.DirectoryItems;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.InformationConverter;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Directory.DirectoryTreeCreators.FileArrayRetrievers;

public class WindowsFilesRetriever : IFilesArrayRetriever
{
    public IEnumerable<DirectoryItem> GetFiles(FileSystemContext context, string path)
    {
        var directoryItems = GetDirectoryItems(path).ToList();
        List<DirectoryItem> items = new();
        var converter = new ConverterInfoRelatedToOperatingSystem(context);

        foreach (string item in directoryItems)
        {
            var directoryItem = new DirectoryItem(item);
            directoryItem.WithParentDirectory(converter.GetPathRelatedToSystem(path));
            items.Add(directoryItem);
        }

        return items;
    }

    private static IEnumerable<string> GetDirectoryItems(string path)
    {
        return System.IO.Directory.GetFiles(path, "*");
    }
}