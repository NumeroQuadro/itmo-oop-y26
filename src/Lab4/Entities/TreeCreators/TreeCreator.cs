using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.TreeCreators;

public class TreeCreator
{
    private int _depth;

    public TreeCreator(int depth)
    {
        _depth = depth;
    }

    public FolderItem BuildFileSystemTree(string rootPath)
    {
        var rootFolder = new FolderItem(Path.GetFileName(rootPath));
        PopulateFileSystemTree(_depth, rootPath, rootFolder);
        return new FolderItem(rootPath, rootFolder.Children.Reverse());
    }

    private void PopulateFileSystemTree(int currentDepth, string path, FolderItem folder)
    {
        if (currentDepth <= 0)
        {
            return;
        }

        IEnumerable<string> subdirectories = Directory.GetDirectories(path);
        foreach (string subdirectory in subdirectories)
        {
            var subFolder = new FolderItem(Path.GetFileName(subdirectory));
            PopulateFileSystemTree(currentDepth - 1, subdirectory, subFolder);
            folder.AddChildren(subFolder);
        }

        IEnumerable<string> files = Directory.GetFiles(path);
        foreach (string file in files)
        {
            var fileNode = new FileItem(Path.GetFileName(file));
            folder.AddChildren(fileNode);
        }
    }
}