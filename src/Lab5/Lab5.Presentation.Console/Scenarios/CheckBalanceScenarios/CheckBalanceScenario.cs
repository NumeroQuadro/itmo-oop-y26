using Lab5.Application.Contracts.Users;
using Lab5.Application.Models.Balance;
using Lab5.Application.Models.Users;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.CheckBalanceScenario;

public class CheckBalanceScenario : IScenario
{
    private readonly IUserService _userService;
    private User _user;

    public CheckBalanceScenario(IUserService userService, User user)
    {
        _userService = userService;
        _user = user;
    }

    public string Name => "Check balance";
    public void Run()
    {
        CheckBalanceResult result = _userService.CheckBalance(_user.Username);

        string message = result switch
        {
            CheckBalanceResult.Success success => $"Your balance is ${success.Balance}",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
    }
}