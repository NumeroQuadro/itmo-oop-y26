using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messangers;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessangerAdressees;

public class MessangerAdresse : IAdressee
{
    private readonly IMessanger _messanger;

    public MessangerAdresse(IMessanger messanger)
    {
        _messanger = messanger;
    }

    public void ReceiveMessage(Message message)
    {
        _messanger.ReceiveMessage(message.Content);
    }

    private static string ArgumentsToLogMessage()
    {
        return "Messanger received message";
    }
}