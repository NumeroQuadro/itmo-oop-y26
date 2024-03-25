using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Transactions;
using Lab5.Application.Contracts.Users;

namespace Lab5.Presentation.Console.Scenarios.ViewTransactionHistoryScenarios;

public class ViewTransactionHistoryScenarioProvider : IScenarioProvider
{
    private readonly ITransactionSerivce _transactionSerivce;
    private readonly ICurrentUserService _currentUser;

    public ViewTransactionHistoryScenarioProvider(ITransactionSerivce transactionSerivce, ICurrentUserService currentUser)
    {
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

        scenario = new ViewTransactionHistoryScenario(_transactionSerivce, _currentUser.User);
        return true;
    }
}