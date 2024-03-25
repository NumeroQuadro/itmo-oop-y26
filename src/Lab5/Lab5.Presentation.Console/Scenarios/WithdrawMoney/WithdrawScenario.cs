using Lab5.Application.Contracts.Transactions;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Models.Balance;
using Lab5.Application.Models.Transactions;
using Lab5.Application.Models.Users;
using Lab5.Presentation.Console.Models;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.WithdrawMoney;

public class WithdrawScenario : IScenario
{
    private readonly IUserService _withdrawBalanceService;
    private readonly ITransactionSerivce _transactionSerivce;
    private User _user;

    public WithdrawScenario(IUserService withdrawBalanceService, ITransactionSerivce transactionSerivce, User user)
    {
        _withdrawBalanceService = withdrawBalanceService;
        _transactionSerivce = transactionSerivce;
        _user = user;
    }

    public string Name => "Withdraw money";
    public ScenarioResult Run()
    {
        decimal amount = AnsiConsole.Ask<decimal>("Enter the amount you want to withdraw");

        UpdateBalanceResult result = _withdrawBalanceService.WithdrawMoney(_user.Balance, _user.Username, amount);
        _transactionSerivce.RecordTransaction(TransactionType.Withdraw, _user.Username, amount);

        if (result is UpdateBalanceResult.Success)
        {
            return new ScenarioResult.Success(this, "Successful withdrawal");
        }

        if (result is UpdateBalanceResult.NotEnoughMoney)
        {
            return new ScenarioResult.Failure("Not enough money");
        }

        return new ScenarioResult.Failure("User not found");
    }
}