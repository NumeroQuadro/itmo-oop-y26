using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.TreeCreators;

public interface IVisitor
{
    public void ExtractFile(int currentDepth, TreeListWritingOptions options, FileItem fileItem);
    public void ExtractFolder(int currentDepth, TreeListWritingOptions options, FolderItem folderItem);
}