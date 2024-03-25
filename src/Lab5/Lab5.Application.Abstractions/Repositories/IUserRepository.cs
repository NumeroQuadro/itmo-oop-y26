using Lab5.Application.Models.Users;

namespace Lab5.Application.Abstractions.Repositories;

public interface IUserRepository
{
    public Task<User?> FindUserByUsername(string username);
    public Task<Admin?> FindAdminByUsername(string username);
    public Task<decimal?> GetBalance(string username);
    public Task UpdateBalance(string username, decimal amount);
}