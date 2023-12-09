using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts;

public interface IContextBuilder
{
    public CommandExecutionResult Build();
}