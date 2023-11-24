using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.FileCopyCommandContexts.FileCopyValidators;

public interface IFileCopyValidator
{
    public CommandContextValidationResult Validate(string sourcePath, string destinationPath);
}