using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.GotoCommandContexts.GotoCommandValidators;

public interface IGotoValidator
{
    public CommandContextValidationResult Validate(string path);
}