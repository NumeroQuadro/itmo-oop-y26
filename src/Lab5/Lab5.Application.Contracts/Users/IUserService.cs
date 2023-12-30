using Lab5.Application.Models.Balance;

namespace Lab5.Application.Contracts.Users;

public interface IUserService
{
    LoginResult Login(string username, string password);
    FindUserResult FindUserByUsername(string username);
    public UpdateBalanceResult WithdrawMoney(decimal currentBalance, string username, decimal amount);
    public UpdateBalanceResult DepositMoney(decimal currentBalance, string username, decimal amount);
    public CheckBalanceResult CheckBalance(string username);
}