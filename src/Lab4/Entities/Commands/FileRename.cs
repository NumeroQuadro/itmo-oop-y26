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
            File.Move(_context.Path, _context.Name);
            File.Delete(_context.Path);
        }
        catch (Exception e)
        {
            return new CommandExecutionResult.ExecutedWithFailure($"rename failed: {e.Message}");
        }

        return new CommandExecutionResult.ExecutedSuccessfully("rename executed successfully");
    }
}