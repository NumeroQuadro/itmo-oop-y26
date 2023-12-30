using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.Users;

namespace Lab5.Presentation.Console.Scenarios.CreateAccountScenarios;

public class CreateAccountScenarioProvider : IScenarioProvider
{
    private readonly ICurrentUserService _currentUser;
    private readonly IAccountService _accountService;

    public CreateAccountScenarioProvider(ICurrentUserService currentUser, IAccountService accountService)
    {
        _currentUser = currentUser;
        _accountService = accountService;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)]out IScenario? scenario)
    {
        if (_currentUser.User is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new CreateAccountScenario(_accountService);
        return true;
    }
}