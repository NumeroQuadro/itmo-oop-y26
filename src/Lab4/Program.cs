using Itmo.ObjectOrientedProgramming.Lab4.Entities.AppStateInformation.AppStateInitial;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.QueryHandlers;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public static class Program
{
    public static void Main(string[] args)
    {
        var appContext = new FileSystemContext();
        appContext.WithTreeListWritingOptions("  ", "├──", "└──");
        var queryHandler = new QueryHandler();
        queryHandler.HandleQuery(args, appContext);
    }
}