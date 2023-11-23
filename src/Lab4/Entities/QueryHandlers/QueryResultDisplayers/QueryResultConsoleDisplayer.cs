using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.QueryHandlers.QueryResultDisplayers;

public class QueryResultConsoleDisplayer : IQueryResultDisplayer
{
    public void Display(IEnumerable<string> messages)
    {
        foreach (string message in messages)
        {
            System.Console.WriteLine(message);
        }
    }
}