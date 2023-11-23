using Itmo.ObjectOrientedProgramming.Lab4.Entities.QueryHandlers;
using AppContext = Itmo.ObjectOrientedProgramming.Lab4.Entities.AppStateInformation.AppStateInitial.AppContext;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public static class Program
{
    public static void Main(string[] args)
    {
        var appContext = new AppContext();
        var queryHandler = new QueryHandler();
        queryHandler.HandleQuery(args, appContext);
    }
}