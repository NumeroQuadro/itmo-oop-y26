using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Filters;

public class FilterAddressee : IAdressee
{
    private readonly IAdressee _adressee;
    private readonly int _importanceLevel;

    public FilterAddressee(IAdressee adressee, int importanceLevel)
    {
        _adressee = adressee;
        _importanceLevel = importanceLevel;
    }

    public void ReceiveMessage(Message message)
    {
        if (message.ImportanceLevel >= _importanceLevel)
        {
            _adressee.ReceiveMessage(message);
        }
    }
}