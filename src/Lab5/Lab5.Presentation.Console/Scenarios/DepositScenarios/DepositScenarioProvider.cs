using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Transactions;
using Lab5.Application.Contracts.Users;

namespace Lab5.Presentation.Console.Scenarios.DepositScenarios;

public class DepositScenarioProvider : IScenarioProvider
{
    private readonly IUserService _service;
    private readonly ITransactionSerivce _transactionSerivce;
    private readonly ICurrentUserService _currentUser;

    public DepositScenarioProvider(IUserService service, ITransactionSerivce transactionSerivce, ICurrentUserService currentUser)
    {
        _service = service;
        _transactionSerivce = transactionSerivce;
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

        scenario = new DepositScenario(_service, _transactionSerivce, _currentUser.User);
        return true;
    }
}