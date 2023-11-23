using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.ConsoleErrorMessagesWriter;

public class SuccessResultMessageDisplayer : ISuccessResultMessageDisplayer
{
    public void DisplaySuccessMessage(string successMessage)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(successMessage);
        Console.ResetColor();
    }
}