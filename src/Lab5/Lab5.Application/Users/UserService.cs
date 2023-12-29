using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Users;
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
}