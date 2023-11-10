using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Users.MessageStates;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users;

public class User
{
    private readonly List<MessageStatus> _messages;

    public User()
    {
        _messages = new List<MessageStatus>();
    }

    public IEnumerable<MessageStatus> Messages => _messages;

    public static IMessageState MarkMessageRead(MessageStatus message)
    {
        IMessageState result = message.MarkMessageAsRead();

        return result;
    }

    public void GetMessage(Message message)
    {
        var messageState = new MessageUnread();

        _messages.Add(new MessageStatus(message.Content, messageState));
    }
}