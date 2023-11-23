namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public record CommandContextValidationResult
{
    private CommandContextValidationResult()
    { }

    public sealed record Success : CommandContextValidationResult;

    public sealed record Failure(string FailureMessage) : CommandContextValidationResult;
}