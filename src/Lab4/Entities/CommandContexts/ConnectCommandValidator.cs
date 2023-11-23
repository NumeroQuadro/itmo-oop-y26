using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.ConnectCommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts;

public class ConnectCommandValidator : IConnectCommandValidator
{
    public CommandContextValidationResult Validate(string path, ConnectMode mode)
    {
        if (mode != ConnectMode.Console)
        {
            return new CommandContextValidationResult.Failure("Non Console-Mode is not supported");
        }

        if (!Path.Exists(path))
        {
            return new CommandContextValidationResult.Failure("Path does not exist");
        }

        return new CommandContextValidationResult.Success();
    }
}