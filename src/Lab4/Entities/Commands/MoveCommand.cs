using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.AppStateInformation.AppStateInitial;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.MoveCommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class MoveCommand : ICommand
{
    private MoveContext _moveContext;

    public MoveCommand(MoveContext moveContext)
    {
        _moveContext = moveContext;
    }

    public CommandExecutionResult Execute(FileSystemContext fileSystemContext)
    {
        try
        {
            File.Move(_moveContext.SourcePath, _moveContext.DestinationPath);
        }
        catch (UnauthorizedAccessException e)
        {
            return new CommandExecutionResult.ExecutedWithFailure($"Failed to move file {e.Message}");
        }
        catch (ArgumentException e)
        {
            return new CommandExecutionResult.ExecutedWithFailure($"Failed to move file {e.Message}");
        }
        catch (DirectoryNotFoundException e)
        {
            return new CommandExecutionResult.ExecutedWithFailure($"Failed to move file {e.Message}");
        }
        catch (IOException e)
        {
            return new CommandExecutionResult.ExecutedWithFailure($"Failed to move file {e.Message}");
        }
        catch (NotSupportedException e)
        {
            return new CommandExecutionResult.ExecutedWithFailure($"Failed to move file {e.Message}");
        }

        return new CommandExecutionResult.ExecutedSuccessfully("File moved successfully");
    }
}