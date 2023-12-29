using Lab5.Application.Contracts.Users;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.LoginScenario;

public class LoginScenario : IScenario
{
    private readonly IUserService _userService;

    public LoginScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Login";
    public void Run()
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

        string message = result switch
        {
            LoginResult.Success => "Successful login",
            LoginResult.PasswordMismatch => "Password mismatch",
            LoginResult.NotFound => "User not found",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}