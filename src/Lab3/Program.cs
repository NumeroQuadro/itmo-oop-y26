using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.MessangerAdressees;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public static class Program
{
    public static void Main()
    {
        var message = new Message("dimon", 2);
        var aggregator = new MessangerAdresse();
        aggregator.GetMessage(message);
    }
}