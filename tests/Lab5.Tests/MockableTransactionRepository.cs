using System.Collections.Generic;
using System.Threading.Tasks;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.Transactions;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class MockableTransactionRepository : ITransactionRepository
{
    public Task RecordTransaction(TransactionType type, string username, decimal amount)
    {
        return Task.CompletedTask;
    }

    public Task<IEnumerable<Transaction>?> ViewTransactionHistoryForUserByUsername(string username)
    {
        return Task.FromResult<IEnumerable<Transaction>?>(null);
    }
}