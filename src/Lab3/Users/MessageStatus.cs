using Itmo.ObjectOrientedProgramming.Lab3.Users.MessageStates;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users;

public class MessageStatus
{
    private readonly string _message;
    private IMessageState _messageState;
    public MessageStatus(string message, IMessageState messageState)
    {
        _message = message;
        _messageState = messageState;
    }

    public string Message => _message;
    public IMessageState MessageState => _messageState;

    public IMessageState MarkMessageAsRead()
    {
        return _messageState.MoveToRead();
    }
}