using System;
using Itmo.ObjectOrientedProgramming.Lab3.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Users;

namespace Itmo.ObjectOrientedProgramming.Lab3.UserAdressees;

public class UserAdressee : IAdressee
{
    private readonly Lazy<User> _user = new Lazy<User>(() => new User());
    private readonly ILogger _logger = new Logger();

    public void GetMessage(Message message)
    {
        _logger.LogEvent(ArgumentsToLogMessage());
        _user.Value.GetMessage(message);
    }

    private static string ArgumentsToLogMessage()
    {
        return "User reveived message";
    }
}