using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.DisconnectCommandContexts;

public record DisconnectContext : ICommandContext
{
    public ICommand GetCommand()
    {
        return new Disconnect(this);
    }
}