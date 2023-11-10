using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.GroupAdressees;

public class GroupAdressee
{
    private readonly List<IAdressee> _adressees;
    private readonly ILogger _logger;

    public GroupAdressee(IEnumerable<IAdressee> adressees, ILogger logger)
    {
        _adressees = adressees.ToList();
        _logger = logger;
    }

    public void GetMessage(Message message)
    {
        foreach (IAdressee adressee in _adressees)
        {
            _logger.LogEvent(ArgumentsToLogMessage(adressee));
            adressee.GetMessage(message);
        }
    }

    private static string ArgumentsToLogMessage(IAdressee adressee)
    {
        return $"{nameof(adressee.ToString)} reveived message";
    }
}