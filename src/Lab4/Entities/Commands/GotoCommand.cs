using Itmo.ObjectOrientedProgramming.Lab4.Entities.AppStateInformation.AppStateInitial;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.GotoCommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class GotoCommand : ICommand
{
    private GotoContext _gotoContext;

    public GotoCommand(GotoContext gotoContext)
    {
        _gotoContext = gotoContext;
    }

    public ICommandContext CommandContext => _gotoContext;

    public CommandExecutionResult Execute(FileSystemContext fileSystemContext)
    {
        fileSystemContext.WithCurrentDirectory(_gotoContext.Path);

        return new CommandExecutionResult.ExecutedSuccessfully($"Current directory is {_gotoContext.Path}");
    }
}