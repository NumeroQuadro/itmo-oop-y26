using Lab5.Presentation.Console.Models;

namespace Lab5.Presentation.Console.ScenarioResultHandlers;

public interface IScenarioResultHandler
{
    public void Handle(ScenarioResult result);
}