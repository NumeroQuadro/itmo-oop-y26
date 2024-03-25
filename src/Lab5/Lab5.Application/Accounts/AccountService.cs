using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Models.Account;
using Lab5.Application.Models.Users;

namespace Lab5.Application.Accounts;

public class AccountService : IAccountService
{
    private readonly IUserRepository _userRepository;
    private readonly IAccountRepository _accountRepository;

    public AccountService(IUserRepository userRepository, IAccountRepository accountRepository)
    {
        _userRepository = userRepository;
        _accountRepository = accountRepository;
    }

    public CreateAccountResult CreateUserAccount(string stringRole, string username, string password, decimal initialBalance)
    {
        Task<User?> user = _userRepository.FindUserByUsername(username);
        Task<Admin?> admin = _userRepository.FindAdminByUsername(username);

        if (user.Result is null && admin.Result is null)
        {
            if (stringRole == "User")
            {
                _accountRepository.CreateUserAccount(username, UserType.User, password, initialBalance);
                return new CreateAccountResult.Success(username, initialBalance);
            }

            _accountRepository.CreateUserAccount(username, UserType.Admin, password, initialBalance);
        }

        if (user.Result is not null)
        {
            return new CreateAccountResult.Failure("User with this username already exists");
        }

        return new CreateAccountResult.Failure("Admin with this username already exists");
    }
}