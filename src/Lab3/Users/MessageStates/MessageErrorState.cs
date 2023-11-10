namespace Itmo.ObjectOrientedProgramming.Lab3.Users.MessageStates;

public class MessageErrorState : IMessageState
{
    public IMessageState MoveToRead()
    {
        return this;
    }

    public IMessageState MoveToUnread()
    {
        return this;
    }
}