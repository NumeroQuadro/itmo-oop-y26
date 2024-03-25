using Lab5.Application.Models.Transactions;

namespace Lab5.Application.Contracts.Transactions;

public interface ITransactionSerivce
{
    public void RecordTransaction(TransactionType type, string username, decimal amount);
    public ViewTransactionResult ViewTransactionHistoryForUserByUsername(string username);
}