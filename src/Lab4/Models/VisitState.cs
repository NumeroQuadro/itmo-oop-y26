namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public abstract record VisitState
{
    public sealed record Visited : VisitState;
    public sealed record NotVisited : VisitState;
}