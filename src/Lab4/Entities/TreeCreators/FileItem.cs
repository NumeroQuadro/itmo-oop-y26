using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.TreeCreators;

public class FileItem : IVisitorItem
{
    private string _pathFileItem;

    public FileItem(string pathFileItem)
    {
        _pathFileItem = pathFileItem;
    }

    public string Name => _pathFileItem;

    public VisitState VisitState { get; private set; } = new VisitState.NotVisited();

    public void Accept(int currentDepth, TreeListWritingOptions options, IVisitor visitor)
    {
        VisitState = new VisitState.Visited();
        visitor.ExtractFile(currentDepth, options, this);
    }
}