using Lab5.Application.Models.Transactions;
using Lab5.Application.Models.Users;

namespace Lab5.Application.Contracts.Transactions;

public interface ITransactionSerivce
{
    public void RecordTransaction(TransactionType type, string username, decimal amount);
}