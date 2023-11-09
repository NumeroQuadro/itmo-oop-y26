using Itmo.ObjectOrientedProgramming.Lab3.DisplayAddresses;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Topics;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public static class Program
{
    public static void Main()
    {
        var displayAdressee = new DisplayAdressee();
        var topic = new Topic(displayAdressee, "dimon", 2);
        var message = new Message("hello dimon", 4);
        topic.RedirectMessage(message);
        displayAdressee.Print();
    }
}