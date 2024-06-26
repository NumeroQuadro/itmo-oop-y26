using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Models.Balance;
using Lab5.Application.Models.Users;

namespace Lab5.Application.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly CurrentUserManager _currentUserManager;

    public UserService(IUserRepository repository, CurrentUserManager currentUserManager)
    {
        _repository = repository;
        _currentUserManager = currentUserManager;
    }

    public LoginResult Login(string username, string password)
    {
        Task<User?> user = _repository.FindUserByUsername(username);

        if (user.Result is null)
        {
            return new LoginResult.NotFound();
        }

        _currentUserManager.User = user.Result;
        if (_currentUserManager.User.Password != password)
        {
            return new LoginResult.PasswordMismatch();
        }

        return new LoginResult.Success();
    }

    public FindUserResult FindUserByUsername(string username)
    {
        Task<User?> user = _repository.FindUserByUsername(username);

        if (user.Result is null)
        {
            return new FindUserResult.NotFound();
        }

        return new FindUserResult.Success();
    }

    public UpdateBalanceResult WithdrawMoney(decimal currentBalance, string username, decimal amount)
    {
        if (currentBalance < amount)
        {
            return new UpdateBalanceResult.NotEnoughMoney();
        }

        _repository.UpdateBalance(username, currentBalance - amount);

        return new UpdateBalanceResult.Success();
    }

    public UpdateBalanceResult DepositMoney(decimal currentBalance, string username, decimal amount)
    {
        _repository.UpdateBalance(username, currentBalance + amount);

        return new UpdateBalanceResult.Success();
    }

    public CheckBalanceResult CheckBalance(string username)
    {
        Task<decimal?> balance = _repository.GetBalance(username);

        if (balance.Result is null)
        {
            return new CheckBalanceResult.BalanceInformationNotFound();
        }

        return new CheckBalanceResult.Success(balance.Result.Value);
    }
}