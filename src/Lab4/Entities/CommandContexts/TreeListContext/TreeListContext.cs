using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.TreeListContext;

public record TreeListContext(int Depth) : ICommandContext
{
    public ICommand GetCommand()
    {
        return new TreeList(this);
    }
}