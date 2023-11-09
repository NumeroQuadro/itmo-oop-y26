using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messangers;

public class Messanger : IMessanger
{
    private readonly List<string> _messages;

    public Messanger()
    {
        _messages = new List<string>();
    }

    public void GetMessage(string message)
    {
        _messages.Add(message);
    }

    public string Deliver()
    {
        string results = _messages.Aggregate("From messanger: ", (s, m) => new MessangerTextPrinter(m).Deliver());

        return results;
    }
}