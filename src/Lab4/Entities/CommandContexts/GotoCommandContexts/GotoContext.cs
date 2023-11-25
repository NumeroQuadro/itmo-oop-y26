using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.GotoCommandContexts;

public record GotoContext(string Path) : ICommandContext
{
    public ICommand GetCommand()
    {
        return new GotoCommand(this);
    }
}