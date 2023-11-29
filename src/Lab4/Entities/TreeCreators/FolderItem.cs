using System.Collections.Generic;
using System.Collections.ObjectModel;
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

    public FolderItem(string pathFolderItem, IEnumerable<IVisitorItem> reversedChildren)
    {
        _pathFolderItem = pathFolderItem;
        _children = new List<IVisitorItem>(reversedChildren);
    }

    public IEnumerable<IVisitorItem> Children => _children;
    public string Name => _pathFolderItem;
    public VisitState VisitState { get; private set; } = new VisitState.NotVisited();

    public void AddChildren(IVisitorItem child)
    {
        _children.Add(child);
    }

    public void Accept(Collection<string> treeContent, int currentDepth, TreeListWritingOptions options, IVisitor visitor)
    {
        VisitState = new VisitState.Visited();
        visitor.ExtractFolder(treeContent, currentDepth, options, this);
    }
}