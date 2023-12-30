using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Transactions;
using Lab5.Application.Models.Transactions;

namespace Lab5.Application.Transactions;

public class RecordTransactionService : ITransactionSerivce
{
    private readonly ITransactionRepository _transactionRepository;

    public RecordTransactionService(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public void RecordTransaction(TransactionType type, string username, decimal amount)
    {
        _transactionRepository.RecordTransaction(type, username, amount);
    }

    public ViewTransactionResult ViewTransactionHistoryForUserByUsername(string username)
    {
        Task<IEnumerable<Transaction>?> transactions = _transactionRepository.ViewTransactionHistoryForUserByUsername(username);

        if (transactions.Result is null)
        {
            return new ViewTransactionResult.Failure("No transactions found for user.");
        }

        return new ViewTransactionResult.Success(transactions.Result);
    }
}