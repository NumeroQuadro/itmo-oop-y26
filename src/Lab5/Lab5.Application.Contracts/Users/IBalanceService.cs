using Lab5.Application.Models.Balance;

namespace Lab5.Application.Contracts.Users;

public interface IBalanceService
{
    public UpdateBalanceResult WithdrawMoney(string username, decimal amount);
    public UpdateBalanceResult DepositMoney(string username, decimal amount);
}