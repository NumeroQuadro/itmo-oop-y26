namespace Lab5.Presentation.Console.Models;

public abstract record ScenarioResult
{
    private ScenarioResult() { }

    public sealed record Success(IScenario Scenario, string ScenarioSuccessfulText) : ScenarioResult;
    public sealed record Failure(string ErrorMessage) : ScenarioResult;
}