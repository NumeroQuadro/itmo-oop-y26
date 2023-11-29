using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.TreeCreators;

public class VisitorItemsExtractor : IVisitor
{
    public void ExtractFile(int currentDepth, TreeListWritingOptions options, FileItem fileItem)
    {
        Console.WriteLine(string.Concat(Enumerable.Repeat(options.Indentation, currentDepth)) + options.FilePrefix + fileItem.Name);
    }

    public void ExtractFolder(int currentDepth, TreeListWritingOptions options, FolderItem folderItem)
    {
        Console.WriteLine(string.Concat(Enumerable.Repeat(options.Indentation, currentDepth)) + options.DirectoryPrefix + folderItem.Name);

        foreach (IVisitorItem child in folderItem.Children)
        {
            child.Accept(currentDepth + 1, options, new VisitorItemsExtractor());
        }
    }
}