using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Loggers;

public class Logger : ILogger
{
    public string LogEvent(string eventInformation)
    {
        Console.WriteLine($"{eventInformation}");

        return eventInformation;
    }
}