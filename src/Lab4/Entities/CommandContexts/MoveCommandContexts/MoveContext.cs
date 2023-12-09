using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.MoveCommandContexts;

public record MoveContext(string SourcePath, string DestinationPath) : ICommandContext
{
    public ICommand GetCommand()
    {
        return new MoveCommand(this);
    }
}