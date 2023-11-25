using Itmo.ObjectOrientedProgramming.Lab4.Entities.AppStateInformation.AppStateInitial;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.DisconnectCommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class Disconnect : ICommand
{
    private DisconnectContext _context;

    public Disconnect(DisconnectContext context)
    {
        _context = context;
    }

    public ICommandContext CommandContext => _context;

    public CommandExecutionResult Execute(FileSystemContext fileSystemContext)
    {
        fileSystemContext.WithAbsolutePath(string.Empty);
        fileSystemContext.WithAbsolutePath(string.Empty);
        fileSystemContext.WithCurrentDirectory(string.Empty);

        return new CommandExecutionResult.ExecutedSuccessfully("Disconnected successfully");
    }
}