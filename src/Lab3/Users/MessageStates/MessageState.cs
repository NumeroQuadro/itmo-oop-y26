namespace Itmo.ObjectOrientedProgramming.Lab3.Users.MessageStates;

public class MessageState
{
    private IMessageState _state;

    public MessageState()
    {
        _state = new MessageUnread();
    }

    public ReadingResult MarkMessageAsRead()
    {
        return _state.MoveToRead();
    }

    public ReadingResult MarkMessageAsUnread()
    {
        return _state.MoveToUnread();
    }
}