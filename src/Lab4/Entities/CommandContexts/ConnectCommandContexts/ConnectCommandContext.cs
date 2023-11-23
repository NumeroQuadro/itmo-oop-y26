using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.ConnectCommandContexts;

public record ConnectCommandContext(string Path, ConnectMode Mode) : ICommandContext
{
    public ICommand GetCommand()
    {
        return new ConnectCommand(this);
    }
}