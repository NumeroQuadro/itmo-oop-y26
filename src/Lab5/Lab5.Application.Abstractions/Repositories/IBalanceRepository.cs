namespace Lab5.Application.Abstractions.Repositories;

public interface IBalanceRepository
{
    public Task UpdateBalance(string username, decimal amount);
}