using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Loggers;

public class ConsoleLogger : ILogger
{
    public string LogEvent(string eventInformation)
    {
        return $"[{DateTime.Now}] {eventInformation}";
    }
}