using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.ColoredConsoleTextDisplayer;

public class ItemPrinter
{
    private IItem _item;

    public ItemPrinter(IItem item)
    {
        _item = item;
    }

    public void Print()
    {
        Console.Clear();
        Console.WriteLine(_item.Render());
    }
}