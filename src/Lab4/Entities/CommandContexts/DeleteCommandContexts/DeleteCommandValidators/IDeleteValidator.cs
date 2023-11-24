using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.DeleteCommandContexts.DeleteCommandValidators;

public interface IDeleteValidator
{
    public CommandContextValidationResult Validate(string path);
}