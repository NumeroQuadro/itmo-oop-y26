using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.ShowFileCommandContexts.ShowFileValidators;

public class ShowFileValidator : IShowFileValidator
{
    public CommandContextValidationResult Validate(string path, ConnectMode mode)
    {
        if (mode != ConnectMode.Local)
        {
            return new CommandContextValidationResult.Failure("Non Console-Mode for command \"file show\" is not supported");
        }

        if (!Path.Exists(path))
        {
            return new CommandContextValidationResult.Failure("Path does not exist as an argument for \"file show\" command");
        }

        return new CommandContextValidationResult.Success();
    }
}