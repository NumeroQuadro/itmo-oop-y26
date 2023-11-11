using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.ColoredConsoleTextDisplayer;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class Display : IPrinter
{
    private readonly List<string> _messages = new();

    public void GetMessage(string message)
    {
        _messages.Add(message);
    }

    public void Print()
    {
        var driver = new DisplayDriver();
        foreach (string x in _messages)
        {
            driver.Print(x);
        }
    }
}