using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messangers;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessangerAdressees;

public class MessangerAdresse : IAdressee
{
    private readonly Messanger _messanger;

    public MessangerAdresse(Messanger messanger)
    {
        _messanger = messanger;
    }

    public void GetMessage(Message message)
    {
        _messanger.GetMessage(message.Content);
    }

    public string Print()
    {
        return _messanger.Deliver();
    }

    private static string ArgumentsToLogMessage()
    {
        return "Messanger received message";
    }
}