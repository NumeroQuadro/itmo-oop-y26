using Itmo.ObjectOrientedProgramming.Lab4.Entities.AppStateInformation.AppStateInitial;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.QueryHandlers;

public interface IQueryHandler
{
    public void HandleQuery(string[] args, FileSystemContext fileSystemContext);
}