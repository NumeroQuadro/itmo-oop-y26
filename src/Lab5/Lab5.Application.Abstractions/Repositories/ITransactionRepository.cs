using Lab5.Application.Models.Transactions;
using Lab5.Application.Models.Users;

namespace Lab5.Application.Abstractions.Repositories;

public interface ITransactionRepository
{
    public Task RecordTransaction(TransactionType type, string username, decimal amount);
}