using Lab5.Presentation.Console.Models;
using Spectre.Console;

namespace Lab5.Presentation.Console.ScenarioResultHandlers;

public class ConsoleScenarioResultHandler : IScenarioResultHandler
{
    public void Handle(ScenarioResult result)
    {
        if (result is ScenarioResult.Success success)
        {
            AnsiConsole.MarkupLine($"[green]{success.ScenarioSuccessfulText}[/]");
        }

        if (result is ScenarioResult.Failure failure)
        {
            AnsiConsole.MarkupLine($"[red]{failure.ErrorMessage}[/]");
        }

        AnsiConsole.Ask<string>("Choose what to do next. Press any key and Enter to see variants");
    }
}