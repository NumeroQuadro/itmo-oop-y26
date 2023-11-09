using System;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Users;

namespace Itmo.ObjectOrientedProgramming.Lab3.UserAdressees;

public class UserAdressee : IAdressee
{
    private readonly Lazy<User> _user = new Lazy<User>(() => new User());

    public void GetMessage(Message message)
    {
        _user.Value.GetMessage(message);
    }
}