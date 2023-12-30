using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.Users;
using Npgsql;

namespace DataAccess.Repositrories;

public class AccountRepository : IAccountRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AccountRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task CreateUserAccount(string username, UserType type, string password, decimal initialBalance)
    {
        const string updateBalanceRequest =
            """
            INSERT INTO Users (Username, user_type, Password, Balance)
            VALUES (:username, :type, :password, :initialBalance);
            """;
        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default);

        await using var command = new NpgsqlCommand(updateBalanceRequest, connection);
        command.AddParameter("Username", username);
        command.AddParameter("user_type", type);
        command.AddParameter("Password", password);
        command.AddParameter("Balance", initialBalance);

        await command.ExecuteNonQueryAsync();
    }
}