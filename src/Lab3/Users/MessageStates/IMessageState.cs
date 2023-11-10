namespace Itmo.ObjectOrientedProgramming.Lab3.Users.MessageStates;

public interface IMessageState
{
    IMessageState MoveToRead();
    IMessageState MoveToUnread();
}