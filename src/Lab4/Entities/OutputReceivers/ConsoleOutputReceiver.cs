using System;
using System.Collections.Generic;
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
            if (result is CommandExecutionResult.ExecutedSuccessfully)
            {
                Console.WriteLine("Command executed successfully");
            }
            else if (result is CommandExecutionResult.ExecutedWithFailure executedWithFailure)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(executedWithFailure.FailureMessage);
                Console.ResetColor();
            }
            else if (result is CommandExecutionResult.RetrievedSuccessfully)
            {
                Console.WriteLine("Command retrieved successfully");
            }
            else if (result is CommandExecutionResult.RetrievedWithFailure retrievedWithFailure)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(retrievedWithFailure.FailureMessage);
                Console.ResetColor();
            }
        }
    }
}