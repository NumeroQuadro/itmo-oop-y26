using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.QueryHandlers;

public interface IQueryHandler
{
    public IEnumerable<CommandExecutionResult> HandleQuery(IEnumerable<string> args, ApplicationContext applicationContext);
}