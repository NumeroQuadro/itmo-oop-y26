using Lab5.Application.Contracts.Transactions;
using Lab5.Application.Models.Transactions;
using Lab5.Application.Models.Users;
using Lab5.Presentation.Console.Models;

namespace Lab5.Presentation.Console.Scenarios.ViewTransactionHistoryScenarios;

public class ViewTransactionHistoryScenario : IScenario
{
    private readonly ITransactionSerivce _transactionSerivce;
    private User _user;

    public ViewTransactionHistoryScenario(ITransactionSerivce transactionSerivce, User user)
    {
        _transactionSerivce = transactionSerivce;
        _user = user;
    }

    public string Name => "View transaction history";
    public ScenarioResult Run()
    {
        ViewTransactionResult result = _transactionSerivce.ViewTransactionHistoryForUserByUsername(_user.Username);

        if (result is ViewTransactionResult.Failure failure)
        {
            return new ScenarioResult.Failure($"Some issues occurred while deriving transaction history: {failure.Reason}");
        }

        return new ScenarioResult.Success(this, "Transaction history derived successfully");
    }
}