using Itmo.ObjectOrientedProgramming.Lab3.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayAddresses;

public class DisplayAdressee : IAdressee
{
    private readonly Display _display;

    public DisplayAdressee(Display display)
    {
        _display = display;
    }

    public void ReceiveMessage(Message message)
    {
        _display.ReceiveMessage(message.Content);
    }
}