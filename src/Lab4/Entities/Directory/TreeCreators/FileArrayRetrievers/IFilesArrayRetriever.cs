using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.AppStateInformation.AppStateInitial;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Directory.DirectoryItems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Directory.DirectoryTreeCreators.FileArrayRetrievers;

public interface IFilesArrayRetriever
{
    public IEnumerable<DirectoryItem> GetFiles(FileSystemContext context, string path);
}