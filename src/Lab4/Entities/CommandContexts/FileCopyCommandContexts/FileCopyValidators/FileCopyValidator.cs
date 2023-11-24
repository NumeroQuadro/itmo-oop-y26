using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.FileCopyCommandContexts.FileCopyValidators;

public class FileCopyValidator : IFileCopyValidator
{
    public CommandContextValidationResult Validate(string sourcePath, string destinationPath)
    {
        if (string.IsNullOrWhiteSpace(sourcePath))
        {
            return new CommandContextValidationResult.Failure("Source path for command file copy is empty");
        }

        if (string.IsNullOrWhiteSpace(destinationPath))
        {
            return new CommandContextValidationResult.Failure("Destination path for command file copy is empty");
        }

        return new CommandContextValidationResult.Success();
    }
}