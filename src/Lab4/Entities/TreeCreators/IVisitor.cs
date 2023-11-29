using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.TreeCreators;

public interface IVisitor
{
    public void ExtractFile(Collection<string> treeContent, int currentDepth, TreeListWritingOptions options, FileItem fileItem);
    public void ExtractFolder(Collection<string> treeContent, int currentDepth, TreeListWritingOptions options, FolderItem folderItem);
}