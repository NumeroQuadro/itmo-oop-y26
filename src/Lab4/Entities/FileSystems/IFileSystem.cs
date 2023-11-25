namespace Itmo.ObjectOrientedProgramming.Lab4.Entities;

public interface IFileSystem
{
    public void MoveFile(string sourcePath, string destinationPath);
    public void DeleteFile(string path);
    public void Disconnect();
    public void CopyFile(string sourcePath, string destinationPath);
    public void ChangeDirectory(string destinationPath);
    public void ShowFile(string path);
}