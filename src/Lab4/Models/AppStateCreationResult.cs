using Itmo.ObjectOrientedProgramming.Lab4.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public abstract record AppStateCreationResult
{
    private AppStateCreationResult() { }

    public record Success(ApplicationContext ApplicationContext) : AppStateCreationResult;
    public record Failure(string FailureMessage) : AppStateCreationResult;
}