using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Users.MessageStates;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users;

public class User
{
    private readonly List<MessageWithStatus> _messages;

    public User()
    {
        _messages = new List<MessageWithStatus>();
    }

    public IEnumerable<MessageWithStatus> Messages => _messages;

    public MessageReadChangeModeResult MarkMessageRead(Message message)
    {
        IEnumerable<MessageWithStatus> foundMessages = _messages.Select(x => x).Where(x => x.Message == message.Content);
        IEnumerable<MessageReadChangeModeResult> results = foundMessages.Select(x => x.MarkMessageAsRead());

        return results.First();
    }

    public MessageReadChangeModeResult MarkMessageUnread(Message message)
    {
        IEnumerable<MessageWithStatus> foundMessages = _messages.Select(x => x).Where(x => x.Message == message.Content);
        IEnumerable<MessageReadChangeModeResult> results = foundMessages.Select(x => x.MarkMessageAsUnread());

        return results.First();
    }

    public void GetMessage(Message message)
    {
        var messageState = new MessageUnread();

        _messages.Add(new MessageWithStatus(message.Content, messageState));
    }
}