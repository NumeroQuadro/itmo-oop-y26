using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.DisconnectCommandContexts;

public class DisconnectContextBuilder : IContextBuilder
{
    public CommandExecutionResult Build()
    {
        return new CommandExecutionResult.RetrievedSuccessfully(new DisconnectContext());
    }
}