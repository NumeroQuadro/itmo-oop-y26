using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.ShowFileCommandContexts;

public record ShowFileContext(string Path, ConnectMode Mode) : ICommandContext
{
    public ICommand GetCommand()
    {
        return new ShowFile(this);
    }
}