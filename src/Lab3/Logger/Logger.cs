using System;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Topics;

namespace Itmo.ObjectOrientedProgramming.Lab3.Logger;

public class Logger : ILogger
{
    private readonly Topic _topic;

    public Logger(int importanceLevel, IAdressee adressee)
    {
        _topic = new Topic(adressee, "Logger", importanceLevel);
    }

    public void ProccessMessage(Message message)
    {
        LogEvent(message);
        _topic.RedirectMessage(message);
    }

    public void LogEvent(Message message)
    {
        Console.WriteLine($"[message with importance level {message.ImportanceLevel}] was reveived: {message.Content}");
    }
}