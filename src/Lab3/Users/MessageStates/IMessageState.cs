namespace Itmo.ObjectOrientedProgramming.Lab3.Users.MessageStates;

public interface IMessageState
{
    public MessageReadStatus ReadStatus { get; }
    MessageReadChangeModeResult MoveToRead();
    MessageReadChangeModeResult MoveToUnread();
}