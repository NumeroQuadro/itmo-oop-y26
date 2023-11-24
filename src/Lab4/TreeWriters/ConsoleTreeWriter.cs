using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class ConsoleTreeWriter : ITreeWriter
{
    public void DisplayTreeItem(IEnumerable<string> items)
    {
        foreach (string item in items)
        {
            Console.WriteLine(item);
        }
    }
}