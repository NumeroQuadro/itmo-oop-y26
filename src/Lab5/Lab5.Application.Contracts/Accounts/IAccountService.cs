using Lab5.Application.Models.Account;

namespace Lab5.Application.Contracts.Accounts;

public interface IAccountService
{
    public CreateAccountResult CreateUserAccount(string stringRole, string username, string password, decimal initialBalance);
}