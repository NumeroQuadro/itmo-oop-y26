using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Users;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topics;

public class Topic : IFilter
{
    private readonly IAdressee _adressee;
    private readonly int _messageImportanceLevel;
    private string _name;

    public Topic(IAdressee adressee, string name, int messageImportanceLevel)
    {
        _messageImportanceLevel = messageImportanceLevel;
        _adressee = adressee;
        _name = name;
    }

    public MessageStatus? RedirectMessage(Message message)
    {
        Message? filteredMessage = PassThroughFilter(message);
        if (filteredMessage is not null)
        {
            return _adressee.GetMessage(filteredMessage);
        }

        return null;
    }

    public Message? PassThroughFilter(Message message)
    {
        if (message.ImportanceLevel >= _messageImportanceLevel)
        {
            return message;
        }

        return null;
    }
}