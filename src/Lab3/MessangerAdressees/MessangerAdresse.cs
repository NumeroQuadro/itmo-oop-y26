using System;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messangers;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessangerAdressees;

public class MessangerAdresse : IAdressee
{
    private readonly Lazy<IDeliverer> _messanger = new Lazy<IDeliverer>(() => new Messanger());

    public void GetMessage(Message message)
    {
        _messanger.Value.GetMessage(message.Content);
    }
}