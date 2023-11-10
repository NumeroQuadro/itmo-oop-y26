using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Users;
using Itmo.ObjectOrientedProgramming.Lab3.Users.MessageStates;

namespace Itmo.ObjectOrientedProgramming.Lab3.UserAdressees;

public class UserAdressee : IAdressee
{
    private readonly Lazy<User> _user = new Lazy<User>(() => new User());
    private readonly ILogger _logger = new Logger();

    public IEnumerable<MessageStatus> GetUserReceivedMessagesStatuses => _user.Value.Messages;

    public MessageStatus GetMessage(Message message)
    {
        _logger.LogEvent(ArgumentsToLogMessage());
        _user.Value.GetMessage(message);

        var messageState = new MessageUnread();

        return new MessageStatus(message.Content, messageState);
    }

    private static string ArgumentsToLogMessage()
    {
        return "User reveived message";
    }
}