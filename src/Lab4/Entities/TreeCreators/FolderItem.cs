using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.TreeCreators;

public class FolderItem : IVisitorItem
{
    private string _pathFolderItem;
    private List<IVisitorItem> _children = new List<IVisitorItem>();

    public FolderItem(string pathFolderItem)
    {
        _pathFolderItem = pathFolderItem;
    }

    public IEnumerable<IVisitorItem> Children => _children;
    public string Name => _pathFolderItem;
    public VisitState VisitState { get; private set; } = new VisitState.NotVisited();

    public void AddChildren(IVisitorItem child)
    {
        _children.Add(child);
    }

    public void Accept(string indentationItem, IVisitor visitor)
    {
        VisitState = new VisitState.Visited();
        visitor.ExtractFolder(this);
    }

    public string PathWithIndentationAndIcon(string indentationItem)
    {
        return indentationItem + _pathFolderItem;
    }
}