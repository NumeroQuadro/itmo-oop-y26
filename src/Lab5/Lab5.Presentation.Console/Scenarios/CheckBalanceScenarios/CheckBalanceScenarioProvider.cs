using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Users;

namespace Lab5.Presentation.Console.Scenarios.CheckBalanceScenarios;

public class CheckBalanceScenarioProvider : IScenarioProvider
{
    private readonly IUserService _service;
    private readonly ICurrentUserService _currentUser;

    public CheckBalanceScenarioProvider(IUserService service, ICurrentUserService currentUser)
    {
        _service = service;
        _currentUser = currentUser;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User is null)
        {
            scenario = null;
            return false;
        }

        scenario = new CheckBalanceScenario(_service, _currentUser.User);
        return true;
    }
}