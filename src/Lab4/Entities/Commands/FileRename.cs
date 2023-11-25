using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.FileRenameContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class FileRename : ICommand
{
    private FileRenameContext _context;

    public FileRename(FileRenameContext context)
    {
        _context = context;
    }

    public ICommandContext CommandContext => _context;

    public CommandExecutionResult Execute(ApplicationContext applicationContext)
    {
        try
        {
            if (applicationContext.FileSystem is null)
            {
                return new CommandExecutionResult.ExecutedWithFailure(
                    "FileSystem is not connected. Use connect command for connecting to fie system!");
            }

            string destinationPath = string.Concat(applicationContext.FileSystem.GetCurrentPath, _context.Name);
            File.Move(_context.Path, destinationPath);
            File.Delete(_context.Path);
        }
        catch (Exception e)
        {
            return new CommandExecutionResult.ExecutedWithFailure($"rename failed: {e.Message}");
        }

        return new CommandExecutionResult.ExecutedSuccessfully("rename executed successfully");
    }
}