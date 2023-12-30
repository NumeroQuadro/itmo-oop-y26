using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.Users;
using Npgsql;

namespace DataAccess.Repositrories;

public class UserRepository : IUserRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public UserRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<User?> FindUserByUsername(string username)
    {
        const string findUserByUsernameRequest = """
           select UserID, Username, Password, Balance
           from Users
           where Username = :username;
        """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default);

        await using var command = new NpgsqlCommand(findUserByUsernameRequest, connection);
        command.AddParameter("username", username);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        if (await reader.ReadAsync() is false)
            return null;

        return new User(
            Username: reader.GetString(1),
            Password: reader.GetString(2),
            Balance: await reader.GetFieldValueAsync<decimal>(3));
    }

    public async Task UpdateBalance(string username, decimal amount)
    {
        const string updateBalanceRequest = """
                                                UPDATE Users SET Balance = :amount WHERE Username = :username;
                                            """;
        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default);

        await using var command = new NpgsqlCommand(updateBalanceRequest, connection);
        command.AddParameter("Username", username);
        command.AddParameter("Balance", amount);

        await command.ExecuteNonQueryAsync();
    }

    public async Task<decimal?> GetBalance(string username)
    {
        const string checkBalanceRequest = """
            SELECT Balance FROM Users WHERE Username = :username;
        """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default);

        await using var command = new NpgsqlCommand(checkBalanceRequest, connection);
        command.AddParameter("Username", username);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        if (await reader.ReadAsync() is false)
            return null;

        return await reader.GetFieldValueAsync<decimal>(0);
    }
}