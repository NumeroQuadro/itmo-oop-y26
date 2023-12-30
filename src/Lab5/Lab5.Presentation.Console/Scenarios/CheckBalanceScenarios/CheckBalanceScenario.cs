using Lab5.Application.Contracts.Users;
using Lab5.Application.Models.Balance;
using Lab5.Application.Models.Users;
using Lab5.Presentation.Console.Models;

namespace Lab5.Presentation.Console.Scenarios.CheckBalanceScenarios;

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
    public ScenarioResult Run()
    {
        CheckBalanceResult result = _userService.CheckBalance(_user.Username);

        if (result is CheckBalanceResult.Success success)
        {
            return new ScenarioResult.Success(this, $"Your balance is {success.Balance}");
        }

        return new ScenarioResult.Failure("Balance information not found");
    }
}