using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.GotoCommandContexts.GotoCommandValidators;

public class GotoValidator : IGotoValidator
{
    public CommandContextValidationResult Validate(string path)
    {
        if (!Path.Exists(path))
        {
            return new CommandContextValidationResult.Failure("Path does not exist");
        }

        return new CommandContextValidationResult.Success();
    }
}