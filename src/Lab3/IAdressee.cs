using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public interface IAdressee
{
    public void ReceiveMessage(Message message);
}