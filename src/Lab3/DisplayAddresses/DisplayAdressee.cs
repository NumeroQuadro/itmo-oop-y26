using System;
using Itmo.ObjectOrientedProgramming.Lab3.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Users;
using Itmo.ObjectOrientedProgramming.Lab3.Users.MessageStates;

namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayAddresses;

public class DisplayAdressee : IAdressee
{
    private readonly Lazy<Display> _display = new Lazy<Display>(() => new Display());
    private readonly Logger _logger = new Logger();

    public MessageStatus GetMessage(Message message)
    {
        _logger.LogEvent(ArgumentsToLogMessage());
        _display.Value.GetMessage(message.Content);

        var messageState = new MessageUnread();

        return new MessageStatus(message.Content, messageState);
    }

    public void Print()
    {
        _display.Value.Print();
    }

    private static string ArgumentsToLogMessage()
    {
        return "Display reveived message";
    }
}