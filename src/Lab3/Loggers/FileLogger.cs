using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab3.Loggers;

public class FileLogger : ILogger
{
    public string LogEvent(string eventInformation)
    {
        const string path = "D:\\ITMO_OOP\\DIMAB3-ITMO\\src\\Lab3\\.log";
        using var streamWriter = new StreamWriter(path, true);
        streamWriter.WriteLine(eventInformation);

        return eventInformation;
    }
}