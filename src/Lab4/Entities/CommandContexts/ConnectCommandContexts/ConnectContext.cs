using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.ConnectCommandContexts;

public record ConnectContext(string Path, ConnectMode Mode) : ICommandContext
{
    public ICommand GetCommand()
    {
        return new ConnectCommand(this);
    }
}