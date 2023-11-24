using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.AppStateInformation.AppStateInitial;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Directory.DirectoryTreeCreators;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.QueryHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public static class Program
{
    public static void Main(string[] args)
    {
        var appContext = new FileSystemContext();
        var queryHandler = new QueryHandler();
        queryHandler.HandleQuery(args, appContext);
        var treeDisplayer = new DirectoryItemsTreeCreator();
        TreeCreationResult r = treeDisplayer.Create(appContext, appContext.AbsolutePath);

        if (r is TreeCreationResult.TreeCreatedSuccessfully)
        {
            Console.WriteLine("dimon limon top");
        }
    }
}