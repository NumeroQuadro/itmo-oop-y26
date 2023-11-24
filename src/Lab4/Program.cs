using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.AppStateInformation.AppStateInitial;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandLineSeparators;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.QueryHandlers;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public static class Program
{
    public static void Main()
    {
        var appContext = new FileSystemContext();
        appContext.WithTreeListWritingOptions("  ", "├──", "└──");

        while (true)
        {
            string? userInput = Console.ReadLine();
            var separator = new CommandLineSpaceSeparator();

            while (true)
            {
                var queryHandler = new QueryHandler();
                queryHandler.HandleQuery(separator.Separate(userInput), appContext);
                break;
            }
        }
    }
}