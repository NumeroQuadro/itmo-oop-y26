using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Loggers;

public class LoggerAddressee : IAdressee
{
    private readonly IAdressee _adressee;
    private readonly ILogger _logger;

    public LoggerAddressee(IAdressee adressee, ILogger logger)
    {
        _adressee = adressee;
        _logger = logger;
    }

    public void ReceiveMessage(Message message)
    {
        _logger.LogEvent(message.Content);
        _adressee.ReceiveMessage(message);
    }
}