namespace Itmo.ObjectOrientedProgramming.Lab4;

public record ValidationResult
{
    private ValidationResult()
    { }

    public sealed record Success : ValidationResult;

    public sealed record Failure : ValidationResult;
}