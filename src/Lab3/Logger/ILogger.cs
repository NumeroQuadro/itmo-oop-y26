using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Logger;

public interface ILogger
{
    public void LogEvent(Message message);
}