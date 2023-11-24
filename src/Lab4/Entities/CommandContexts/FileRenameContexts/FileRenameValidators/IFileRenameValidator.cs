using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.FileRenameContexts.FileRenameValidators;

public interface IFileRenameValidator
{
    public CommandContextValidationResult Validate(string sourcePath, string name);
}