namespace Itmo.ObjectOrientedProgramming.Lab3.Users.MessageStates;

public interface IMessageState
{
    ReadingResult MoveToRead();
    ReadingResult MoveToUnread();
}