using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.ColoredConsoleTextDisplayer;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class Display
{
    private readonly List<string> _messages = new();

    public void GetMessage(string message)
    {
        _messages.Add(message);
    }

    public IEnumerable<string> Print()
    {
        IEnumerable<ConsoleColorTextPrinter> printers = _messages.Select(x => new ConsoleColorTextPrinter(x));
        IEnumerable<string> results = printers.Select(e => e.Print());

        return results;
    }
}