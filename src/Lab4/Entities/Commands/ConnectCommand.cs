using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.ConnectCommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using AppContext = Itmo.ObjectOrientedProgramming.Lab4.Entities.AppStateInformation.AppStateInitial.AppContext;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class ConnectCommand : ICommand
{
    private readonly ConnectContext _context;

    public ConnectCommand(ConnectContext context)
    {
        _context = context;
    }

    public CommandExecutionResult Execute(AppContext appContext)
    {
        appContext.WithAbsolutePath(_context.Path);
        appContext.WithConnectMode(_context.Mode);
        appContext.WithCurrentDirectory(_context.Path);
        appContext.WithOsPlatform(Environment.OSVersion);

        return new CommandExecutionResult
            .ExecutedSuccessfully($"Connect command executed successfully! Absolute path {_context.Path} is set. Mode is {_context.Mode}. Your system is {Environment.OSVersion}");
    }
}