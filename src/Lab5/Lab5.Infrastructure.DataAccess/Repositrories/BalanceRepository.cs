using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.Application.Abstractions.Repositories;
using Npgsql;

namespace DataAccess.Repositrories;

public class BalanceRepository : IBalanceRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public BalanceRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task UpdateBalance(string username, decimal amount)
    {
        const string updateBalanceRequest = """
            UPDATE Users SET Balance = :amount WHERE Username = :username;
        """;
        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(true);

        await using var command = new NpgsqlCommand(updateBalanceRequest, connection);
        command.AddParameter("Username ", username);
        command.AddParameter("Balance", amount);

        await command.ExecuteNonQueryAsync();
    }
}