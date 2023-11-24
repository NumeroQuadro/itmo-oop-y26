namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public abstract record TreeCreationResult
{
    private TreeCreationResult() { }

    public sealed record TreeCreatedSuccessfully() : TreeCreationResult;

    public sealed record TreeCreationFailed(string FailureMessage) : TreeCreationResult;
}