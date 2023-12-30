using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Transactions;
using Lab5.Application.Contracts.Users;

namespace Lab5.Presentation.Console.Scenarios.WithdrawMoney;

public class WithdrawScenarioProvider : IScenarioProvider
{
    private readonly IUserService _service;
    private readonly ITransactionSerivce _transactionSerivce;
    private readonly ICurrentUserService _currentUser;

    public WithdrawScenarioProvider(IUserService service, ITransactionSerivce transactionSerivce, ICurrentUserService currentUser)
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

        scenario = new WithdrawScenario(_service, _transactionSerivce, _currentUser.User);
        return true;
    }
}