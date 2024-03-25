using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.DeleteCommandContexts;

public record DeleteContext(string Path) : ICommandContext
{
    public ICommand GetCommand()
    {
        return new Delete(this);
    }
}