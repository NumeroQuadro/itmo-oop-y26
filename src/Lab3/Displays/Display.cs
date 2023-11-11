using System.Collections.Generic;
using System.Linq;
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
        IEnumerable<ConsoleColorTextPrinter> printers = _messages.Select(x => new ConsoleColorTextPrinter(x));
        foreach (ConsoleColorTextPrinter printer in printers)
        {
            printer.Print();
        }
    }
}