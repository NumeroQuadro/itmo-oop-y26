using System;
using Itmo.ObjectOrientedProgramming.Lab3.DisplayDriver.Modifiers.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayDriver;

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