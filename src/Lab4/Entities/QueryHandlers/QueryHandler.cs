using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.AppStateInformation.AppStateInitial;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.InformationConverter;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.OutputReceivers;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.ParserOrganizers;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.QueryHandlers;

public class QueryHandler : IQueryHandler
{
    public void HandleQuery(string[] args, AppContext appContext)
    {
        var parserOrganizer = new ParserOrganizer();
        CommandExecutionResult retrieveringResult = parserOrganizer.Retrieve(args);

        var converter = new ConverterInfoRelatedToOperatingSystem(appContext);
        var results = new List<CommandExecutionResult>();

        if (retrieveringResult is CommandExecutionResult.RetrievedSuccessfully success)
        {
            ICommand command = success.CommandContext.GetCommand();
            CommandExecutionResult executionResult = command.Execute(appContext);
            results.Add(executionResult);
        }
        else if (retrieveringResult is CommandExecutionResult.RetrievedWithFailure failure)
        {
            results.Add(failure);
        }

        IOutputReceiver receiver = converter.GetOutputReceiver(results);
        receiver.DisplayMessages();
    }
}