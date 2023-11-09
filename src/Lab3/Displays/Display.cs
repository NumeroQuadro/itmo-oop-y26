using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.ColoredConsoleTextDisplayer;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class Display
{
    private readonly List<Message> _messages = new();

    public void GetMessage(Message message)
    {
        _messages.Add(message);
    }

    public IEnumerable<string> Print()
    {
        IEnumerable<ConsoleColorTextPrinter> printers = _messages.Select(x => new ConsoleColorTextPrinter(x.Content));
        IEnumerable<string> results = printers.Select(e => e.Print());

        return results;
    }
}