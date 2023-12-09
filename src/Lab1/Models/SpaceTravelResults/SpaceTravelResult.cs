namespace Itmo.ObjectOrientedProgramming.Lab1.Models.SpaceTravelResults;

public abstract record SpaceTravelResult
{
    private SpaceTravelResult() { }

    public sealed record Success : SpaceTravelResult;
    public sealed record ShuttleLost : SpaceTravelResult;
    public sealed record ShuttleIsDestroyed : SpaceTravelResult;
    public sealed record ImpossibleToGoToEnvironment : SpaceTravelResult;
    public sealed record CrewDeath : SpaceTravelResult;
}