using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.QueryHandlers.QueryResultDisplayers;

public interface IQueryResultDisplayer
{
    public void Display(IEnumerable<string> messages);
}