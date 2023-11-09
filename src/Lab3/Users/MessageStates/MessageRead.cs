namespace Itmo.ObjectOrientedProgramming.Lab3.Users.MessageStates;

public class MessageRead : IMessageState
{
    public ReadingResult MoveToRead()
    {
        return new ReadingResult.Failure();
    }

    public ReadingResult MoveToUnread()
    {
        return new ReadingResult.Success();
    }
}