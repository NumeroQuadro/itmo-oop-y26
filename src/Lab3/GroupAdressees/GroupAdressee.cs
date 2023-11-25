using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.GroupAdressees;

public class GroupAdressee : IAdressee
{
    private readonly List<IAdressee> _adressees;

    public GroupAdressee(IEnumerable<IAdressee> adressees)
    {
        _adressees = adressees.ToList();
    }

    public void ReceiveMessage(Message message)
    {
        foreach (IAdressee adressee in _adressees)
        {
            adressee.ReceiveMessage(message);
        }
    }
}