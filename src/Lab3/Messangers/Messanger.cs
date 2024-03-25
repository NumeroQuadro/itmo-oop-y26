namespace Itmo.ObjectOrientedProgramming.Lab3.Messangers;

public class Messanger : IMessanger
{
    private MessangerTextPrinter _printer;

    public Messanger(MessangerTextPrinter printer)
    {
        _printer = printer;
    }

    public void ReceiveMessage(string message)
    {
        Deliver(message);
    }

    public void Deliver(string value)
    {
        _printer.Print(value);
    }
}