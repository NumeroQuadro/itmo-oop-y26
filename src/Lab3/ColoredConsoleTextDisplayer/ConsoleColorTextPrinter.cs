using System;
using Itmo.ObjectOrientedProgramming.Lab3.ColoredConsoleTextDisplayer.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.ColoredConsoleTextDisplayer;

public class ConsoleColorTextPrinter
{
    private IItem _item;

    public ConsoleColorTextPrinter(string content)
    {
        _item = new TextItem(content);
    }

    public string Print()
    {
        Console.Clear();
        Console.WriteLine(_item.Render());

        return _item.Render();
    }
}