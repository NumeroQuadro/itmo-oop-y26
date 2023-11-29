using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.TreeCreators;

public class VisitorItemsExtractor : IVisitor
{
    public void ExtractFile(Collection<string> treeContent, int currentDepth, TreeListWritingOptions options, FileItem fileItem)
    {
        treeContent.Add(string.Concat(Enumerable.Repeat(options.Indentation, currentDepth)) + options.FilePrefix + fileItem.Name);
    }

    public void ExtractFolder(Collection<string> treeContent, int currentDepth, TreeListWritingOptions options, FolderItem folderItem)
    {
        treeContent.Add(string.Concat(Enumerable.Repeat(options.Indentation, currentDepth)) + options.DirectoryPrefix + folderItem.Name);
        foreach (IVisitorItem child in folderItem.Children)
        {
            child.Accept(treeContent, currentDepth + 1, options, new VisitorItemsExtractor());
        }
    }
}