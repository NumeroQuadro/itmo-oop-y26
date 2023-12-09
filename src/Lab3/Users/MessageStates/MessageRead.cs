namespace Itmo.ObjectOrientedProgramming.Lab3.Users.MessageStates;

public class MessageRead : IMessageState
{
    public MessageReadStatus ReadStatus => MessageReadStatus.Read;
    public MessageReadChangeModeResult MoveToRead()
    {
        return new MessageReadChangeModeResult.InvalidChange();
    }

    public MessageReadChangeModeResult MoveToUnread()
    {
        return new MessageReadChangeModeResult.Success(new MessageUnread());
    }
}