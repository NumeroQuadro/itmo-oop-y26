using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messangers;

internal class MessangerTextPrinter : IMessangerPrinter
{
    public void Print(string value)
    {
        string messengerString = "Messenger: ";
        string resultString = $"{messengerString} {value}";
        Console.WriteLine(resultString);
    }
}