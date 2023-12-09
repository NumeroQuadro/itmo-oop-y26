namespace Itmo.ObjectOrientedProgramming.Lab3.Users.MessageStates;

public record MessageReadChangeModeResult
{
    private MessageReadChangeModeResult() { }

    public sealed record Success(IMessageState State) : MessageReadChangeModeResult;

    public sealed record InvalidChange : MessageReadChangeModeResult;
}