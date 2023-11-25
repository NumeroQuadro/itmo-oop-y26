using System;
using System.IO;
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

    public ICommandContext CommandContext => _moveContext;

    public CommandExecutionResult Execute(ApplicationContext applicationContext)
    {
        if (applicationContext.FileSystem is null)
        {
            return new CommandExecutionResult.ExecutedWithFailure("FileSystem is not connected. Use connect command for connecting to fie system!");
        }

        try
        {
            File.Move(_moveContext.SourcePath, _moveContext.DestinationPath);
        }
        catch (Exception e)
        {
            return new CommandExecutionResult.ExecutedWithFailure($"Failed to move file {e.Message}");
        }

        return new CommandExecutionResult.ExecutedSuccessfully("File moved successfully");
    }
}