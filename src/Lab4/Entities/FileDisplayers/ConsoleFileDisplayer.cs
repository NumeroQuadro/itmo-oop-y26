using System;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileDisplayers;

public class ConsoleFileDisplayer : IFileDisplayer
{
    public void Display(string path)
    {
        string fileContents = File.ReadAllText(path);
        Console.WriteLine(fileContents);
    }
}