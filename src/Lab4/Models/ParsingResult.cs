namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public abstract record ParsingResult
{
    private ParsingResult()
    { }

    public sealed record Success : ParsingResult;

    public sealed record Failure(string FailureMessage) : ParsingResult;
}