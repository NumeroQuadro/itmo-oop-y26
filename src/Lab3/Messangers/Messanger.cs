using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messangers;

public class Messanger : IMessanger
{
    private readonly List<string> _messages;

    public Messanger()
    {
        _messages = new List<string>();
    }

    public void GetMessage(string message)
    {
        _messages.Add(message);
    }

    public void Deliver()
    {
        MessangerTextPrinter printer = new();
        foreach (string message in _messages)
        {
            printer.Print(message);
        }
    }
}