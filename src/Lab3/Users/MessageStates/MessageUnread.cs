namespace Itmo.ObjectOrientedProgramming.Lab3.Users.MessageStates;

public class MessageUnread : IMessageState
{
    public MessageReadStatus ReadStatus => MessageReadStatus.Unread;
    public MessageReadChangeModeResult MoveToRead()
    {
        return new MessageReadChangeModeResult.Success(new MessageRead());
    }

    public MessageReadChangeModeResult MoveToUnread()
    {
        return new MessageReadChangeModeResult.InvalidChange();
    }
}