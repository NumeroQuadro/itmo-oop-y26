namespace Itmo.ObjectOrientedProgramming.Lab3.Users.MessageStates;

public class MessageRead : IMessageState
{
    public IMessageState MoveToRead()
    {
        return new MessageErrorState();
    }

    public IMessageState MoveToUnread()
    {
        return new MessageUnread();
    }
}