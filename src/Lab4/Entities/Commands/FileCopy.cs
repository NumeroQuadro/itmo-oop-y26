using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.AppStateInformation.AppStateInitial;
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

    public CommandExecutionResult Execute(FileSystemContext fileSystemContext)
    {
        try
        {
            File.Copy(_context.SourcePath, _context.DestinationPath);
        }
        catch (UnauthorizedAccessException e)
        {
            return new CommandExecutionResult.ExecutedWithFailure($"copy file error: {e.Message}");
        }
        catch (ArgumentNullException e)
        {
            return new CommandExecutionResult.ExecutedWithFailure($"copy file error: {e.Message}");
        }
        catch (ArgumentException e)
        {
            return new CommandExecutionResult.ExecutedWithFailure($"copy file error: {e.Message}");
        }
        catch (PathTooLongException e)
        {
            return new CommandExecutionResult.ExecutedWithFailure($"copy file error: {e.Message}");
        }
        catch (DirectoryNotFoundException e)
        {
            return new CommandExecutionResult.ExecutedWithFailure($"copy file error: {e.Message}");
        }
        catch (FileNotFoundException e)
        {
            return new CommandExecutionResult.ExecutedWithFailure($"copy file error: {e.Message}");
        }
        catch (IOException e)
        {
            return new CommandExecutionResult.ExecutedWithFailure($"copy file error: {e.Message}");
        }
        catch (NotSupportedException e)
        {
            return new CommandExecutionResult.ExecutedWithFailure($"copy file error: {e.Message}");
        }

        return new CommandExecutionResult.ExecutedSuccessfully("file copied successfully");
    }
}