using Itmo.ObjectOrientedProgramming.Lab4.Entities.AppStateInformation.AppStateInitial;

namespace Itmo.ObjectOrientedProgramming.Lab4.QueryHandlers;

public interface IQueryHandler
{
    public void HandleQuery(string[] args, AppContext appContext);
}