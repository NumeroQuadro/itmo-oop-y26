namespace Itmo.ObjectOrientedProgramming.Lab4;

public abstract record ParsingResult
{
    private ParsingResult()
    { }

    public sealed record Success : ParsingResult;

    public sealed record Failure : ParsingResult;
}