using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.DeleteCommandContexts.DeleteCommandValidators;

public class DeleteValidator : IDeleteValidator
{
    public CommandContextValidationResult Validate(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            return new CommandContextValidationResult.Failure("Path for command delete cannot be empty");
        }

        return new CommandContextValidationResult.Success();
    }
}