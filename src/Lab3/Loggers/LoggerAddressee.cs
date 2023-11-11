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

    public void GetMessage(Message message)
    {
        _logger.LogEventToConsole(message.Content);
        _adressee.GetMessage(message);
    }
}