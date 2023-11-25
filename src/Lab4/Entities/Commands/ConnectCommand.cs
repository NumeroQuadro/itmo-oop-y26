using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.AppStateInformation.AppStateInitial;
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

    public CommandExecutionResult Execute(FileSystemContext fileSystemContext)
    {
        fileSystemContext.WithAbsolutePath(_context.Path);
        fileSystemContext.WithConnectMode(_context.Mode);
        fileSystemContext.WithCurrentDirectory(_context.Path);
        fileSystemContext.WithOsPlatform(Environment.OSVersion);

        return new CommandExecutionResult
            .ExecutedSuccessfully($"Connect command executed successfully! Absolute path {_context.Path} is set. Mode is {_context.Mode}. Your system is {Environment.OSVersion}");
    }
}