namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.TreeCreators;

public interface IVisitor
{
    public void ExtractFile(FileItem fileItem);
    public void ExtractFolder(FolderItem folderItem);
}