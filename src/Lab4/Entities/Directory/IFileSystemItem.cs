using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.AppStateInformation.AppStateInitial;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Directory;

public interface IFileSystemItem
{
    public IEnumerable<IFileSystemItem> GetFilesInCurrentDirectory(FileSystemContext context);
    public IEnumerable<string> GetDisplayableItem(FileSystemContext context, int treeDepth);
}