using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.TreeCreators;

public interface IVisitorItem
{
    public string Name { get; }
    public VisitState VisitState { get; }
    public void Accept(int currentDepth, TreeListWritingOptions options, IVisitor visitor);
}