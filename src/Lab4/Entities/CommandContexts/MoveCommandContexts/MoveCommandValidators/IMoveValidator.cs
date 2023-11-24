using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.MoveCommandContexts.MoveCommandValidators;

public interface IMoveValidator
{
    public CommandContextValidationResult Validate(string sourcePath, string destinationPath);
}