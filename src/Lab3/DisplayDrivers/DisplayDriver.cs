using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayDrivers;

public class DisplayDriver : IDisplayDriver
{
    public void Print(string value, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Clear();
        Console.WriteLine(value);
    }

    public void Clear()
    {
        Console.Clear();
    }
}