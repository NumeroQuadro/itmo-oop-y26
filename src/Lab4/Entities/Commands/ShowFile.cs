using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.ShowFileCommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class ShowFile : ICommand
{
    private ShowFileContext _showFileContext;

    public ShowFile(ShowFileContext showFileContext)
    {
        _showFileContext = showFileContext;
    }

    public ICommandContext CommandContext => _showFileContext;

    public CommandExecutionResult Execute(ApplicationContext applicationContext)
    {
        if (applicationContext.FileSystem is null)
        {
            return new CommandExecutionResult.ExecutedWithFailure("FileSystem is not connected. Use connect command for connecting to fie system!");
        }

        try
        {
            string fileToShow = string.Concat(applicationContext.FileSystem.GetCurrentPath, _showFileContext.Path);
            applicationContext.FileSystem.ShowFile(fileToShow);
        }
        catch (Exception e)
        {
            return new CommandExecutionResult.ExecutedWithFailure(e.Message);
        }

        return new CommandExecutionResult.ExecutedSuccessfully("command \"file show\" was executed successfully");
    }
}