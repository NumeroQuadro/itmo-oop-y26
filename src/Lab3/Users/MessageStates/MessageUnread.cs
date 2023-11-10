namespace Itmo.ObjectOrientedProgramming.Lab3.Users.MessageStates;

public class MessageUnread : IMessageState
{
    public IMessageState MoveToRead()
    {
        return new MessageRead();
    }

    public IMessageState MoveToUnread()
    {
        return new MessageErrorState();
    }
}