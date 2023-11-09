using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Loggers;

public class Logger : ILogger
{
    public void LogEvent(string eventInformation)
    {
        Console.WriteLine($"{eventInformation}");
    }
}