using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.Transactions;
using Npgsql;

namespace DataAccess.Repositrories;

public class TransactionRepository : ITransactionRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public TransactionRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task RecordTransaction(TransactionType type, string username, decimal amount)
    {
        const string recordTransactionRequest =
            """
            INSERT INTO TransactionHistory (Username, TransactionType, Amount)
            VALUES (:username, :type, :amount);
            """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default);

        await using var command = new NpgsqlCommand(recordTransactionRequest, connection);
        command.AddParameter("Username", username);
        command.AddParameter("TransactionType", type);
        command.AddParameter("Amount", amount);

        await command.ExecuteNonQueryAsync();
    }

    public async Task<IEnumerable<Transaction>?> ViewTransactionHistoryForUserByUsername(string username)
    {
        const string viewTransactionHistoryForUserByUsername =
            """
            SELECT Username, transaction_type, Amount FROM TransactionHistory
            WHERE Username = :username;
            """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default);

        await using var command = new NpgsqlCommand(viewTransactionHistoryForUserByUsername, connection);
        command.AddParameter("Username", username);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        var transactions = new List<Transaction>();

        while (await reader.ReadAsync())
        {
            var transaction = new Transaction(
                Username: reader.GetString(0),
                Type: await reader.GetFieldValueAsync<TransactionType>(1),
                Amount: await reader.GetFieldValueAsync<decimal>(2));

            transactions.Add(transaction);
        }

        return transactions.Count > 0 ? transactions : null;
    }
}