namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

public interface IFileSystem
{
    public string GetBasePath { get; }
    public string GetCurrentPath { get; }
    public void MoveFile(string sourcePath, string destinationPath);
    public void DeleteFile(string path);
    public void Disconnect();
    public void CopyFile(string sourcePath, string destinationPath);
    public void ChangeDirectory(string destinationPath);
    public void ShowFile(string path);
}