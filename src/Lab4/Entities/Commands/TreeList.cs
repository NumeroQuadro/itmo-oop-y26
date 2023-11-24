using Itmo.ObjectOrientedProgramming.Lab4.Entities.AppStateInformation.AppStateInitial;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class TreeList : ICommand
{
    private int _depth;

    public TreeList(int depth)
    {
        _depth = depth;
    }

    public CommandExecutionResult Execute(FileSystemContext fileSystemContext)
    {
        return new CommandExecutionResult.ExecutedSuccessfully("dimon limon");
    }
}