using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.ConnectCommandContexts;

public interface IConnectCommandContextBuilder
{
    public CommandExecutionResult Build();
}