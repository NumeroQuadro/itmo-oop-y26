using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.AppStateInformation.AppStateInitial;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.ShowFileCommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileDisplayers;
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

    public CommandExecutionResult Execute(FileSystemContext fileSystemContext)
    {
        IFileDisplayer fileDisplayer = new FileDisplayersOrganizer(fileSystemContext).GetFileDisplayerDependingOnSystem();
        try
        {
            fileDisplayer.Display(_showFileContext.Path);
        }
        catch (ArgumentNullException argumentNullException)
        {
            return new CommandExecutionResult.ExecutedWithFailure(argumentNullException.Message);
        }
        catch (ArgumentException argumentException)
        {
            return new CommandExecutionResult.ExecutedWithFailure(argumentException.Message);
        }
        catch (IOException ioException)
        {
            return new CommandExecutionResult.ExecutedWithFailure(ioException.Message);
        }

        return new CommandExecutionResult.ExecutedSuccessfully("command \"file show\" was executed successfully");
    }
}