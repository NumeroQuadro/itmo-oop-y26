namespace Itmo.ObjectOrientedProgramming.Lab3.Messangers;

public interface IMessanger
{
    public void Deliver(string value);
    public void ReceiveMessage(string message);
}