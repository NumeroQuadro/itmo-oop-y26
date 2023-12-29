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
        const string sql = """
           select UserID, Username, Type, Password
           from users
           where Username = :username;
        """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(true);

        // NpgsqlConnection connection = _connectionProvider
        //     .GetConnectionAsync(default)
        //     .GetAwaiter()
        //     .GetResult();
        await using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("username", username);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        if (await reader.ReadAsync().ConfigureAwait(true) is false)
            return null;

        return new User(
            Id: reader.GetInt64(0),
            Username: reader.GetString(1),
            Type: await reader.GetFieldValueAsync<UserType>(2),
            Password: reader.GetString(3));
    }
}