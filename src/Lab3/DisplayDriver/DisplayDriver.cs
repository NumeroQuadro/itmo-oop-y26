using System;
using Itmo.ObjectOrientedProgramming.Lab3.ColoredConsoleTextDisplayer.Modifiers.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.ColoredConsoleTextDisplayer;

public class DisplayDriver : IDisplayDriver
{
    public void Print(string value)
    {
        Console.Clear();
        Console.WriteLine(value);
    }

    public string Modify(string value, IRenderableColorModifier modifier)
    {
        return modifier.Modify(value);
    }

    public void Clear()
    {
        Console.Clear();
    }
}