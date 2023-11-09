using Itmo.ObjectOrientedProgramming.Lab3.Users.MessageStates;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users;

public class MessageStatus
{
    private readonly string _message;
    private MessageState _messageState;
    public MessageStatus(string message, MessageState messageState)
    {
        _message = message;
        _messageState = messageState;
    }

    public string Message => _message;
    public MessageState MessageState => _messageState;

    public ReadingResult MarkMessageAsRead()
    {
        return _messageState.MarkMessageAsRead();
    }
}