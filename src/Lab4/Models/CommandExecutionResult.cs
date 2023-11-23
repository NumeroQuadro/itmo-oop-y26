using Itmo.ObjectOrientedProgramming.Lab4.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public record CommandExecutionResult
{
    private CommandExecutionResult()
    { }

    public sealed record RetrievedSuccessfully(ICommandContext CommandContext) : CommandExecutionResult;

    public sealed record RetrievedWithFailure(string FailureMessage) : CommandExecutionResult;

    public sealed record ExecutedSuccessfully : CommandExecutionResult;

    public sealed record ExecutedWithFailure(string FailureMessage) : CommandExecutionResult;
}