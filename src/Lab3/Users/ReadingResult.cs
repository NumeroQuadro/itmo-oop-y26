namespace Itmo.ObjectOrientedProgramming.Lab3.Users;

public abstract record ReadingResult
{
    public sealed record Success : ReadingResult;
    public sealed record Failure : ReadingResult;
}