using Lab5.Application.Contracts.Users;
using Lab5.Application.Models.Balance;
using Lab5.Application.Models.Users;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.WithdrawMoney;

public class WithdrawScenario : IScenario
{
    private readonly IUserService _withdrawBalanceService;
    private User _user;

    public WithdrawScenario(IUserService withdrawBalanceService, User user)
    {
        _withdrawBalanceService = withdrawBalanceService;
        _user = user;
    }

    public string Name => "Withdraw money";
    public void Run()
    {
        decimal amount = AnsiConsole.Ask<decimal>("Enter the amount you want to withdraw");

        UpdateBalanceResult result = _withdrawBalanceService.WithdrawMoney(_user.Balance, _user.Username, amount);

        string message = result switch
        {
            UpdateBalanceResult.Success => "Successful withdrawal",
            UpdateBalanceResult.NotEnoughMoney => "Not enough money",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
    }
}