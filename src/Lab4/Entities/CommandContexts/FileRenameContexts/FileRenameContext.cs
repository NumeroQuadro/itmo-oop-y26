using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.FileRenameContexts;

public record FileRenameContext(string Path, string Name) : ICommandContext
{
    public ICommand GetCommand()
    {
        return new FileRename(this);
    }
}