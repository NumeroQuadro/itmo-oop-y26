using Lab5.Application.Contracts.Users;
using Lab5.Presentation.Console.Models;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.LoginScenarios;

public class LoginScenario : IScenario
{
    private readonly IUserService _userService;

    public LoginScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Login";
    public ScenarioResult Run()
    {
        string username = AnsiConsole.Ask<string>("Enter your username");

        FindUserResult findResult = _userService.FindUserByUsername(username);

        string findUserMessage = findResult switch
        {
            FindUserResult.Success => "User found",
            FindUserResult.NotFound => "User not found",
            _ => throw new ArgumentOutOfRangeException(nameof(FindUserResult)),
        };

        AnsiConsole.WriteLine(findUserMessage);

        string password = AnsiConsole.Ask<string>("Enter your password");

        LoginResult result = _userService.Login(username, password);

        if (result is LoginResult.PasswordMismatch)
        {
            return new ScenarioResult.Failure("Password mismatch");
        }

        if (result is LoginResult.NotFound)
        {
            return new ScenarioResult.Failure("User not found");
        }

        return new ScenarioResult.Success(this, "Successful login");
    }
}