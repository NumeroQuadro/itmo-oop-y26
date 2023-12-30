using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Models.Account;
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
    public void Run()
    {
        string role = AnsiConsole.Ask<string>("Enter the role you want to sign in as");
        string desiredUsername = AnsiConsole.Ask<string>("Enter the username you want to use");
        string desiredPassword = AnsiConsole.Ask<string>("Enter the password you want to use");
        decimal initialBalance = AnsiConsole.Ask<decimal>("Enter the initial balance");

        CreateAccountResult result = _accountService.CreateUserAccount(role, desiredUsername, desiredPassword, initialBalance);

        string message = result switch
        {
            CreateAccountResult.Success success => $"Successful account create: {success.Username}, {success.InitialBalance}",
            CreateAccountResult.Failure failure => $"Failed to create account: {failure.Reason}",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Choose what do you want to do next");
    }
}