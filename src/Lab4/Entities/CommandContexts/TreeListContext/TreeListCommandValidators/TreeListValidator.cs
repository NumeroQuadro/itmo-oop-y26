using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.TreeListContext.TreeListCommandValidators;

public class TreeListValidator : ITreeListValidator
{
    public CommandContextValidationResult Validate(int depth)
    {
        if (depth < 0)
        {
            return new CommandContextValidationResult.Failure("Depth must be greater than 0");
        }

        return new CommandContextValidationResult.Success();
    }
}