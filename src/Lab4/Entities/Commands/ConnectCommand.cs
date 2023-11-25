using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.ConnectCommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class ConnectCommand : ICommand
{
    private readonly ConnectContext _context;

    public ConnectCommand(ConnectContext context)
    {
        _context = context;
    }

    public ICommandContext CommandContext => _context;

    public CommandExecutionResult Execute(ApplicationContext applicationContext)
    {
        if (!Path.IsPathRooted(_context.Path))
        {
            return new CommandExecutionResult.ExecutedWithFailure("Path should be rooted");
        }

        if (!Path.Exists(_context.Path))
        {
            return new CommandExecutionResult.ExecutedWithFailure("Path does not exist");
        }

        if (_context.Mode is ConnectMode.Local)
        {
            applicationContext.WithFileSystem(new LocalFileSystem(_context.Path, _context.Path));
        }

        return new CommandExecutionResult
            .ExecutedSuccessfully(
                $"Connect command executed successfully! Absolute path {_context.Path} is set. Mode is {_context.Mode}. Your system is {Environment.OSVersion}");
    }
}