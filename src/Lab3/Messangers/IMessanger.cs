namespace Itmo.ObjectOrientedProgramming.Lab3.Messangers;

public interface IMessanger
{
    public string Deliver();
    public void GetMessage(string message);
}