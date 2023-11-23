using Itmo.ObjectOrientedProgramming.Lab4.Entities.AppStateInformation.AppStateInitial;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public abstract record AppStateCreationResult
{
    private AppStateCreationResult() { }

    public record Success(AppContext AppContext) : AppStateCreationResult;
    public record Failure(string FailureMessage) : AppStateCreationResult;
}