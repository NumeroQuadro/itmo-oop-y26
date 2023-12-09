using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messangers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class MockableMessanger : IMessanger
{
    private List<string> _messages = new();

    public IEnumerable<string> Messages => _messages;

    public void ReceiveMessage(string message)
    {
        Deliver(message);
    }

    public void Deliver(string value)
    {
        _messages.Add(value);
    }
}