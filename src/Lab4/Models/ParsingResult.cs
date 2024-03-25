namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public abstract record ParsingResult
{
    private ParsingResult()
    { }

    public sealed record Success : ParsingResult;

    public sealed record FailureCurrentGoToNextParserWithMessage(string FailureMessage) : ParsingResult;
    public sealed record CommandIncorrect(string FailureMessage) : ParsingResult;
}