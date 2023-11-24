using Itmo.ObjectOrientedProgramming.Lab4.Entities.AppStateInformation.AppStateInitial;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Directory.DirectoryTreeCreators;

public interface IDirectoryItemsTreeCreator
{
    public TreeCreationResult Create(FileSystemContext context, IDirectory? currentPathDirectory);
}