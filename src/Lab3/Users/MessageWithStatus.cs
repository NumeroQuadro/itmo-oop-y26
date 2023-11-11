using Itmo.ObjectOrientedProgramming.Lab3.Users.MessageStates;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users;

public class MessageWithStatus
{
    private readonly string _message;
    private IMessageState _messageState;
    public MessageWithStatus(string message, IMessageState messageState)
    {
        _message = message;
        _messageState = messageState;
    }

    public string Message => _message;
    public IMessageState MessageState => _messageState;

    public MessageReadChangeModeResult MarkMessageAsRead()
    {
        return _messageState.MoveToRead();
    }

    public MessageReadChangeModeResult MarkMessageAsUnread()
    {
        return _messageState.MoveToUnread();
    }
}