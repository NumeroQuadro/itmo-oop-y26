using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.ConsoleMessagesWriter;

public class ErrorMessageDisplayer : IErrorMessageDisplayer
{
    public void DisplayErrorMessage(string errorMessage)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(errorMessage);
        Console.ResetColor();
    }
}