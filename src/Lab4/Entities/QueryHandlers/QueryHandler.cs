using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.AppStateInformation.AppStateInitial;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.InformationConverter;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.OutputReceivers;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.ParserOrganizers;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.QueryHandlers;

public class QueryHandler : IQueryHandler
{
    public void HandleQuery(IEnumerable<string> args, FileSystemContext fileSystemContext)
    {
        var parserOrganizer = new ParserOrganizer();
        CommandExecutionResult retrieveringResult = parserOrganizer.Retrieve(args);

        var converter = new ConverterInfoRelatedToOperatingSystem(fileSystemContext);
        var results = new List<CommandExecutionResult>();

        if (retrieveringResult is CommandExecutionResult.RetrievedSuccessfully success)
        {
            ICommand command = success.CommandContext.GetCommand();
            CommandExecutionResult executionResult = command.Execute(fileSystemContext);
            results.Add(executionResult);
        }
        else if (retrieveringResult is CommandExecutionResult.RetrievedWithFailure failure)
        {
            results.Add(failure);
        }

        IOutputReceiver receiver = converter.GetOutputReceiver(results);
        receiver.DisplayResultsInfo();
    }
}