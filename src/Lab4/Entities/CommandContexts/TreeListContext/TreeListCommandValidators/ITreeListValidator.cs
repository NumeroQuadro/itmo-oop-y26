using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.TreeListContext.TreeListCommandValidators;

public interface ITreeListValidator
{
    public CommandContextValidationResult Validate(int depth);
}