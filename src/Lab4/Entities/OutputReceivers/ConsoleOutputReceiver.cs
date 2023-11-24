using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.ConsoleMessagesWriter;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.OutputReceivers;

public class ConsoleOutputReceiver : IOutputReceiver
{
    private readonly IEnumerable<CommandExecutionResult> _results;

    public ConsoleOutputReceiver(IEnumerable<CommandExecutionResult> results)
    {
        _results = results;
    }

    public void DisplayResultsInfo()
    {
        foreach (CommandExecutionResult result in _results)
        {
            if (result is CommandExecutionResult.ExecutedSuccessfully success)
            {
                var displayer = new SuccessResultMessageDisplayer();
                displayer.DisplaySuccessMessage(success.ExecutionDescription);
            }
            else if (result is CommandExecutionResult.ExecutedWithFailure executedWithFailure)
            {
                var displayer = new ErrorMessageDisplayer();
                displayer.DisplayErrorMessage(executedWithFailure.FailureMessage);
            }
            else if (result is CommandExecutionResult.RetrievedSuccessfully)
            {
                var displayer = new SuccessResultMessageDisplayer();
                displayer.DisplaySuccessMessage("Command retrieved successfully");
            }
            else if (result is CommandExecutionResult.RetrievedWithFailure retrievedWithFailure)
            {
                var displayer = new ErrorMessageDisplayer();
                displayer.DisplayErrorMessage(retrievedWithFailure.FailureMessage);
            }
        }
    }
}