using Itmo.ObjectOrientedProgramming.Lab4.Entities.AppStateInformation.AppStateInitial;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.TreeListContext;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class TreeList : ICommand
{
    private TreeListContext _context;

    public TreeList(TreeListContext context)
    {
        _context = context;
    }

    public ICommandContext CommandContext => _context;

    public CommandExecutionResult Execute(FileSystemContext fileSystemContext)
    {
        return new CommandExecutionResult.ExecutedSuccessfully("dimon limon");
    }
}