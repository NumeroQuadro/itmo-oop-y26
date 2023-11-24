using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.FileRenameContexts.FileRenameValidators;

public class FileRenameValidator : IFileRenameValidator
{
    public CommandContextValidationResult Validate(string sourcePath, string name)
    {
        if (string.IsNullOrWhiteSpace(sourcePath))
        {
            return new CommandContextValidationResult.Failure("Source path for file rename command cannot be empty");
        }

        if (string.IsNullOrWhiteSpace(name))
        {
            return new CommandContextValidationResult.Failure("Name cannot be empty");
        }

        return new CommandContextValidationResult.Success();
    }
}