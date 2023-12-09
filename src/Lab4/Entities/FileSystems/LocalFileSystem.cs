using System;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities;

public class LocalFileSystem : IFileSystem
{
    private string _basePath;
    private string _currentPath;

    public LocalFileSystem(string absolutePath, string currentPath)
    {
        _basePath = absolutePath;
        _currentPath = currentPath;
    }

    public string BastPath => _basePath;
    public string CurrentPath => _currentPath;

    public string GetBasePath => _basePath;
    public string GetCurrentPath => _currentPath;

    public void MoveFile(string sourcePath, string destinationPath)
    {
        File.Move(sourcePath, destinationPath);
    }

    public void DeleteFile(string path)
    {
        File.Delete(path);
    }

    public void Disconnect()
    {
        _basePath = string.Empty;
        _currentPath = string.Empty;
    }

    public void CopyFile(string sourcePath, string destinationPath)
    {
        File.Copy(sourcePath, destinationPath);
    }

    public void ChangeDirectory(string destinationPath)
    {
        if (!File.Exists(destinationPath))
        {
            _currentPath = destinationPath;
        }
    }

    public void ShowFile(string path)
    {
        string fileContent = File.ReadAllText(path);
        Console.WriteLine(fileContent);
    }
}