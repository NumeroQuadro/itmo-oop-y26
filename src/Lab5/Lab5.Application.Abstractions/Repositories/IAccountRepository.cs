using Lab5.Application.Models.Users;

namespace Lab5.Application.Abstractions.Repositories;

public interface IAccountRepository
{
    public Task CreateUserAccount(string username, UserType type, string password, decimal initialBalance);
}