using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.DeleteCommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class Delete : ICommand
{
    private readonly DeleteContext _context;

    public Delete(DeleteContext context)
    {
        _context = context;
    }

    public ICommandContext CommandContext => _context;

    public CommandExecutionResult Execute(ApplicationContext applicationContext)
    {
        if (applicationContext.FileSystem is null)
        {
            return new CommandExecutionResult.ExecutedWithFailure(
                "FileSystem is not connected. Use connect command for connecting to fie system!");
        }

        try
        {
            applicationContext.FileSystem.DeleteFile(_context.Path);
        }
        catch (Exception e)
        {
            return new CommandExecutionResult.ExecutedWithFailure($"delete failed: {e.Message}");
        }

        return new CommandExecutionResult.ExecutedSuccessfully("delete executed successfully");
    }
}