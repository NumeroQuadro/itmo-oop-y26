using Lab5.Presentation.Console.Models;

namespace Lab5.Presentation.Console;

public interface IScenario
{
    string Name { get; }
    ScenarioResult Run();
}