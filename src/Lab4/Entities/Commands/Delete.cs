using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.AppStateInformation.AppStateInitial;
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

    public CommandExecutionResult Execute(FileSystemContext fileSystemContext)
    {
        try
        {
            File.Delete(_context.Path);
        }
        catch (ArgumentNullException e)
        {
            return new CommandExecutionResult.ExecutedWithFailure($"delete failed: {e.Message}");
        }
        catch (ArgumentException e)
        {
            return new CommandExecutionResult.ExecutedWithFailure($"delete failed: {e.Message}");
        }
        catch (DirectoryNotFoundException e)
        {
            return new CommandExecutionResult.ExecutedWithFailure($"delete failed: {e.Message}");
        }
        catch (NotSupportedException e)
        {
            return new CommandExecutionResult.ExecutedWithFailure($"delete failed: {e.Message}");
        }
        catch (PathTooLongException e)
        {
            return new CommandExecutionResult.ExecutedWithFailure($"delete failed: {e.Message}");
        }
        catch (UnauthorizedAccessException e)
        {
            return new CommandExecutionResult.ExecutedWithFailure($"delete failed: {e.Message}");
        }
        catch (IOException e)
        {
            return new CommandExecutionResult.ExecutedWithFailure($"delete failed: {e.Message}");
        }

        return new CommandExecutionResult.ExecutedSuccessfully("delete executed successfully");
    }
}