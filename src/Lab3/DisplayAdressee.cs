using System;
using Itmo.ObjectOrientedProgramming.Lab3.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public class DisplayAdressee : IAdressee
{
    private readonly Lazy<Display> _display = new Lazy<Display>(() => new Display());

    public void GetMessage(Message message)
    {
        _display.Value.GetMessage(message.Content);
    }
}