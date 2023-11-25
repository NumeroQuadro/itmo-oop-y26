using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topics;

public class Topic
{
    private readonly IAdressee _adressee;
    private string _name;

    public Topic(IAdressee adressee, string name)
    {
        _adressee = adressee;
        _name = name;
    }

    public void RedirectMessage(Message message)
    {
        _adressee.ReceiveMessage(message);
    }
}