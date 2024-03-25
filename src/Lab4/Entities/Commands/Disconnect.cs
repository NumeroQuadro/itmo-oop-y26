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

    public CommandExecutionResult Execute(ApplicationContext applicationContext)
    {
        if (applicationContext.FileSystem is null)
        {
            return new CommandExecutionResult.ExecutedWithFailure(
                "FileSystem is not connected. use connect command for connecting to file system!");
        }

        applicationContext.FileSystem.Disconnect();

        return new CommandExecutionResult.ExecutedSuccessfully("Disconnected successfully");
    }
}