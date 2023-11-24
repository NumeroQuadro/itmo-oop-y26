using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.MoveCommandContexts.MoveCommandValidators;

public class MoveValidator : IMoveValidator
{
    public CommandContextValidationResult Validate(string sourcePath, string destinationPath)
    {
        if (string.IsNullOrWhiteSpace(sourcePath))
        {
            return new CommandContextValidationResult.Failure("Source path is empty");
        }

        if (string.IsNullOrWhiteSpace(destinationPath))
        {
            return new CommandContextValidationResult.Failure("Destination path is empty");
        }

        return new CommandContextValidationResult.Success();
    }
}