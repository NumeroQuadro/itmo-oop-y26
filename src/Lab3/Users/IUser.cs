namespace Itmo.ObjectOrientedProgramming.Lab3.Users;

public interface IUser
{
    public ReadingResult MarkMessageRead(MessageStatus message);
}