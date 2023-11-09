namespace Itmo.ObjectOrientedProgramming.Lab3.Messangers;

public interface IDeliverer
{
    public string Deliver();
    public void GetMessage(string message);
}