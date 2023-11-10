using System;
using Itmo.ObjectOrientedProgramming.Lab3.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messangers;
using Itmo.ObjectOrientedProgramming.Lab3.Users;
using Itmo.ObjectOrientedProgramming.Lab3.Users.MessageStates;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessangerAdressees;

public class MessangerAdresse : IAdressee
{
    private readonly Lazy<IMessanger> _messanger = new Lazy<IMessanger>(() => new Messanger());
    private readonly ILogger _logger = new Logger();

    public MessageStatus GetMessage(Message message)
    {
        _logger.LogEvent(ArgumentsToLogMessage());
        _messanger.Value.GetMessage(message.Content);

        var messageState = new MessageUnread();

        return new MessageStatus(message.Content, messageState);
    }

    public string Print()
    {
        return _messanger.Value.Deliver();
    }

    private static string ArgumentsToLogMessage()
    {
        return "Messanger reveived message";
    }
}