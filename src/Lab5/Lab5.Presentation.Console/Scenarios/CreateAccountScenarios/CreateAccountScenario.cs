using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Models.Account;
using Lab5.Presentation.Console.Models;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.CreateAccountScenarios;

public class CreateAccountScenario : IScenario
{
    private readonly IAccountService _accountService;

    public CreateAccountScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Create new account";
    public ScenarioResult Run()
    {
        string role = AnsiConsole.Ask<string>("Enter the role you want to sign in as");
        string desiredUsername = AnsiConsole.Ask<string>("Enter the username you want to use");
        string desiredPassword = AnsiConsole.Ask<string>("Enter the password you want to use");
        decimal initialBalance = AnsiConsole.Ask<decimal>("Enter the initial balance");

        CreateAccountResult result = _accountService.CreateUserAccount(role, desiredUsername, desiredPassword, initialBalance);

        if (result is CreateAccountResult.Failure failure)
        {
            return new ScenarioResult.Failure(failure.Reason);
        }

        return new ScenarioResult.Success(this, "Successful account creation");
    }
}