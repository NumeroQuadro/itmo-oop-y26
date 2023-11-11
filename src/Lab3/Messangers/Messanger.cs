namespace Itmo.ObjectOrientedProgramming.Lab3.Messangers;

public class Messanger : IMessanger
{
    public void GetMessage(string message)
    {
        Deliver(message);
    }

    public void Deliver(string value)
    {
        MessangerTextPrinter printer = new();
        printer.Print(value);
    }
}