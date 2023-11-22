using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandContexts;

public class ConnectCommandValidator : IConnectCommandValidator
{
    public ValidationResult Validate(string path, ConnectMode mode)
    {
        if (mode != 0 && Path.Exists(path))
        {
            return new ValidationResult.Success();
        }

        return new ValidationResult.Success();
    }
}