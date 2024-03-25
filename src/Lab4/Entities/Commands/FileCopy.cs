using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.FileCopyCommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class FileCopy : ICommand
{
    private readonly FileCopyContext _context;

    public FileCopy(FileCopyContext context)
    {
        _context = context;
    }

    public ICommandContext CommandContext => _context;

    public CommandExecutionResult Execute(ApplicationContext applicationContext)
    {
        if (applicationContext.FileSystem is null)
        {
            return new CommandExecutionResult.ExecutedWithFailure("FileSystem is not connected. Use connect command for connecting to fie system!");
        }

        try
        {
            string destinationPath = string.Concat(applicationContext.FileSystem.GetBasePath, _context.DestinationPath);
            applicationContext.FileSystem.CopyFile(_context.SourcePath, destinationPath);
        }
        catch (Exception e)
        {
            return new CommandExecutionResult.ExecutedWithFailure($"copy file error: {e.Message}");
        }

        return new CommandExecutionResult.ExecutedSuccessfully("file copied successfully");
    }
}