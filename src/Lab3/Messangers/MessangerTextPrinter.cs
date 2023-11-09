using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messangers;

internal class MessangerTextPrinter
{
    private readonly string _content;

    public MessangerTextPrinter(string content)
    {
        _content = content;
    }

    public string Deliver()
    {
        string messengerString = "Messenger: ";
        string resultString = $"{messengerString} {_content}";
        Console.WriteLine(resultString);

        return resultString;
    }
}