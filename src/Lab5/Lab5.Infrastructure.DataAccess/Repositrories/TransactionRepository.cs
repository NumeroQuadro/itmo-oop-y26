using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.Transactions;
using Lab5.Application.Models.Users;
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
}