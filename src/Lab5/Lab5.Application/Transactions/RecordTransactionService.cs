using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Transactions;
using Lab5.Application.Models.Users;

namespace Lab5.Application.Transaactions;

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
}