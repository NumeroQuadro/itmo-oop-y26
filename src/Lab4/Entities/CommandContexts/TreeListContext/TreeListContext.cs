using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.TreeListContext;

public class TreeListContext : ICommandContext
{
    private int _depth;

    public TreeListContext(int depth)
    {
        _depth = depth;
    }

    public int Depth => _depth;
    public ICommand GetCommand()
    {
        return new TreeList(_depth);
    }
}