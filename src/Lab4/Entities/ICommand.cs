using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities;

public interface ICommand
{
    public ICommandContext CommandContext { get; }
    public CommandExecutionResult Execute(ApplicationContext applicationContext);
}