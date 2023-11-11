namespace Itmo.ObjectOrientedProgramming.Lab3.Loggers;

public interface ILogger
{
    public string LogEventToConsole(string eventInformation);
    public void LogEventToFile(string eventInformation);
}