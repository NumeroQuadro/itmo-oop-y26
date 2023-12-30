using Lab5.Application.Contracts.Transactions;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Models.Balance;
using Lab5.Application.Models.Users;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.DepositScenarios;

public class DepositScenario : IScenario
{
    private readonly IUserService _userService;
    private readonly ITransactionSerivce _transactionSerivce;
    private User _user;

    public DepositScenario(IUserService userService, ITransactionSerivce transactionSerivce, User user)
    {
        _userService = userService;
        _transactionSerivce = transactionSerivce;
        _user = user;
    }

    public string Name => "Deposit money";
    public void Run()
    {
        decimal amount = AnsiConsole.Ask<decimal>("Enter the amount you want to withdraw");

        UpdateBalanceResult result = _userService.DepositMoney(_user.Balance, _user.Username, amount);
        _transactionSerivce.RecordTransaction(TransactionType.Deposit, _user.Username, amount);

        string message = result switch
        {
            UpdateBalanceResult.Success => "Successful deposit",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
    }
}