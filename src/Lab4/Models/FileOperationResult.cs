namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public abstract record FileOperationResult
{
    public sealed record SuccessOperation : FileOperationResult;

    public sealed record FailureOperation(string FailureMessage) : FileOperationResult;
}