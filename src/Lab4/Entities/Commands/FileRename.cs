using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.AppStateInformation.AppStateInitial;
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

    public CommandExecutionResult Execute(FileSystemContext fileSystemContext)
    {
        try
        {
            File.Move(_context.Path, _context.Name);
            File.Delete(_context.Path);
        }
        catch (ArgumentNullException e)
        {
            return new CommandExecutionResult.ExecutedWithFailure($"rename failed: {e.Message}");
        }
        catch (ArgumentException e)
        {
            return new CommandExecutionResult.ExecutedWithFailure($"rename failed: {e.Message}");
        }
        catch (DirectoryNotFoundException e)
        {
            return new CommandExecutionResult.ExecutedWithFailure($"rename failed: {e.Message}");
        }
        catch (NotSupportedException e)
        {
            return new CommandExecutionResult.ExecutedWithFailure($"rename failed: {e.Message}");
        }
        catch (PathTooLongException e)
        {
            return new CommandExecutionResult.ExecutedWithFailure($"rename failed: {e.Message}");
        }
        catch (UnauthorizedAccessException e)
        {
            return new CommandExecutionResult.ExecutedWithFailure($"rename failed: {e.Message}");
        }
        catch (IOException e)
        {
            return new CommandExecutionResult.ExecutedWithFailure($"rename failed: {e.Message}");
        }

        return new CommandExecutionResult.ExecutedSuccessfully("rename executed successfully");
    }
}