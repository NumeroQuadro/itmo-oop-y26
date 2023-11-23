namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public record AppStateValidationResult
{
    private AppStateValidationResult()
    { }

    public sealed record Success : AppStateValidationResult;

    public sealed record Failure(string FailureMessage) : AppStateValidationResult;
}