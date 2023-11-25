using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.TreeCreators;

public class VisitorItemsExtractor : IVisitor
{
    public void ExtractFile(FileItem fileItem)
    {
        Console.WriteLine("    ├── " + fileItem.Name);
    }

    public void ExtractFolder(FolderItem folderItem)
    {
        Console.WriteLine("└── " + folderItem.Name);

        foreach (IVisitorItem child in folderItem.Children)
        {
            child.Accept("--", new VisitorItemsExtractor());
        }
    }
}