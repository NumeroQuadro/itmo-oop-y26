using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandLineSeparators;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.QueryHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public static class Program
{
    public static void Main()
    {
        var appContext = new ApplicationContext(new TreeListWritingOptions("-", "fold:", "fil:"));

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