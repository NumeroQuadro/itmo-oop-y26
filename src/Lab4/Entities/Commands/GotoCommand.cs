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

    public CommandExecutionResult Execute(ApplicationContext applicationContext)
    {
        if (applicationContext.FileSystem is null)
        {
            return new CommandExecutionResult.ExecutedWithFailure(
                "FileSystem is not connected. Use connect command for connecting to fie system!");
        }

        string destinationPath = string.Concat(applicationContext.FileSystem.GetCurrentPath, _gotoContext.Path);
        applicationContext.FileSystem.ChangeDirectory(destinationPath);

        return new CommandExecutionResult.ExecutedSuccessfully($"Current directory is {_gotoContext.Path}");
    }
}