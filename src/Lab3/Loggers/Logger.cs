using System;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab3.Loggers;

public class Logger : ILogger
{
    public string LogEventToConsole(string eventInformation)
    {
        return $"[{DateTime.Now}] {eventInformation}";
    }

    public void LogEventToFile(string eventInformation)
    {
        string path = "D:\\ITMO_OOP\\DIMAB3-ITMO\\src\\Lab3\\.log";
        using (var streamWriter = new StreamWriter(path, true))
        {
            streamWriter.WriteLine(eventInformation);
        }
    }
}