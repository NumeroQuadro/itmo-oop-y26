using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.OutputReceivers;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.ParserOrganizers;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.QueryHandlers;

public class QueryHandler : IQueryHandler
{
    public IEnumerable<CommandExecutionResult> HandleQuery(IEnumerable<string> args, ApplicationContext applicationContext)
    {
        var parserOrganizer = new ParserOrganizer();
        CommandExecutionResult retrieveringResult = parserOrganizer.Retrieve(args);

        var results = new List<CommandExecutionResult>();
        if (retrieveringResult is CommandExecutionResult.RetrievedSuccessfully success)
        {
            ICommand command = success.CommandContext.GetCommand();
            CommandExecutionResult executionResult = command.Execute(applicationContext);
            results.Add(executionResult);
        }
        else if (retrieveringResult is CommandExecutionResult.RetrievedWithFailure failure)
        {
            results.Add(failure);
        }

        IOutputReceiver receiver = new ConsoleOutputReceiver(results);
        receiver.DisplayResultsInfo();

        return results;
    }
}