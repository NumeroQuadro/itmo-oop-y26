using Lab5.Application.Contracts.Users;
using Lab5.Application.Models.Balance;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.LoginScenario;

public class WithdrawScenario : IScenario
{
    private readonly IBalanceService _balanceService;

    public WithdrawScenario(IBalanceService balanceService)
    {
        _balanceService = balanceService;
    }

    public string Name => "Withdraw money";
    public void Run()
    {
        string username = AnsiConsole.Ask<string>("Enter your username");
        decimal amount = AnsiConsole.Ask<decimal>("Enter the amount you want to withdraw");

        UpdateBalanceResult result = _balanceService.WithdrawMoney(username, amount);

        string message = result switch
        {
            UpdateBalanceResult.Success => "Successful withdrawal",
            UpdateBalanceResult.NotEnoughMoney => "Not enough money",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}