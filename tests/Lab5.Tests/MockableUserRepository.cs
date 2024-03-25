using System.Threading.Tasks;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.Users;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class MockableUserRepository : IUserRepository
{
    private decimal _balance;

    public MockableUserRepository(decimal balance)
    {
        _balance = balance;
    }

    public Task<User?> FindUserByUsername(string username)
    {
        return Task.FromResult<User?>(null);
    }

    public Task<Admin?> FindAdminByUsername(string username)
    {
        return Task.FromResult<Admin?>(null);
    }

    public Task<decimal?> GetBalance(string username)
    {
        return Task.FromResult<decimal?>(_balance);
    }

    public Task UpdateBalance(string username, decimal amount)
    {
        _balance = amount;
        return Task.CompletedTask;
    }
}