using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.ConnectCommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using AppContext = Itmo.ObjectOrientedProgramming.Lab4.Entities.AppStateInformation.AppStateInitial.AppContext;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class ConnectCommand : ICommand
{
    private readonly ConnectCommandContext _context;

    public ConnectCommand(ConnectCommandContext context)
    {
        _context = context;
    }

    public CommandExecutionResult Execute(AppContext appContext)
    {
        appContext.WithAbsolutePath(_context.Path);
        appContext.WithConnectMode(_context.Mode);
        appContext.WithCurrentDirectory(_context.Path);
        appContext.WithOsPlatform(Environment.OSVersion);

        return new CommandExecutionResult.ExecutedSuccessfully();
    }
}