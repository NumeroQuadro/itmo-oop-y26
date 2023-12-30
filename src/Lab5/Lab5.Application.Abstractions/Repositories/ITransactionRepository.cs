using Lab5.Application.Models.Transactions;

namespace Lab5.Application.Abstractions.Repositories;

public interface ITransactionRepository
{
    public Task RecordTransaction(TransactionType type, string username, decimal amount);
    public Task<IEnumerable<Transaction>?> ViewTransactionHistoryForUserByUsername(string username);
}