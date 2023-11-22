namespace Itmo.ObjectOrientedProgramming.Lab4.CommandContexts;

public interface IConnectCommandValidator
{
    public ValidationResult Validate(string path, ConnectMode mode);
}