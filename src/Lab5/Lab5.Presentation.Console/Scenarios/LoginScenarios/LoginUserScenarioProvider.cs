using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Users;

namespace Lab5.Presentation.Console.Scenarios.LoginScenarios;

public class LoginUserScenarioProvider : IScenarioProvider
{
    private readonly IUserService _service;
    private readonly ICurrentUserService _currentUser;

    public LoginUserScenarioProvider(
        IUserService service,
        ICurrentUserService currentUser)
    {
        _service = service;
        _currentUser = currentUser;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new LoginScenario(_service);
        return true;
    }
}