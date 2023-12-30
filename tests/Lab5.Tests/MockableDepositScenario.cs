using Lab5.Application.Contracts.Transactions;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Models.Balance;
using Lab5.Application.Models.Users;
using Lab5.Presentation.Console;
using Lab5.Presentation.Console.Models;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class MockableDepositScenario : IScenario
{
    private readonly IUserService _userService;
    private readonly ITransactionSerivce _transactionSerivce;
    private User _user;
    private decimal _amount;

    public MockableDepositScenario(IUserService userService, ITransactionSerivce transactionSerivce, User user, decimal amount)
    {
        _userService = userService;
        _transactionSerivce = transactionSerivce;
        _user = user;
        _amount = amount;
    }

    public string Name => "Deposit";
    public ScenarioResult Run()
    {
        UpdateBalanceResult result = _userService.DepositMoney(_user.Balance, _user.Username, _amount);

        if (result is UpdateBalanceResult.NotEnoughMoney)
        {
            return new ScenarioResult.Failure("Not enough money");
        }

        if (result is UpdateBalanceResult.UserNotFound)
        {
            return new ScenarioResult.Failure("User not found");
        }

        return new ScenarioResult.Success(this, "Success");
    }
}