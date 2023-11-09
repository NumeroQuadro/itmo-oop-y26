using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Users.MessageStates;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users;

public class User : IUser
{
    private readonly List<MessageStatus> _messages;

    public User()
    {
        _messages = new List<MessageStatus>();
    }

    public ReadingResult MarkMessageRead(MessageStatus message)
    {
        ReadingResult result = message.MarkMessageAsRead();

        return result;
    }

    public void GetMessage(Message message)
    {
        var messageState = new MessageState();
        messageState.MarkMessageAsUnread();
        _messages.Add(new MessageStatus(message.Content, messageState));
    }
}