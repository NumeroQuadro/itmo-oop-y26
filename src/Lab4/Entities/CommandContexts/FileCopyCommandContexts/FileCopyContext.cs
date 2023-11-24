using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.FileCopyCommandContexts;

public record FileCopyContext(string SourcePath, string DestinationPath) : ICommandContext
{
    public ICommand GetCommand()
    {
        return new FileCopy(this);
    }
}