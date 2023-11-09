namespace Itmo.ObjectOrientedProgramming.Lab3.Users.MessageStates;

public class MessageUnread : IMessageState
{
    public ReadingResult MoveToRead()
    {
        return new ReadingResult.Success();
    }

    public ReadingResult MoveToUnread()
    {
        return new ReadingResult.Failure();
    }
}