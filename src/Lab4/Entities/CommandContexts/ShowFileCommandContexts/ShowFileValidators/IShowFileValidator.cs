using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.ShowFileCommandContexts.ShowFileValidators;

public interface IShowFileValidator
{
    public CommandContextValidationResult Validate(string path, ConnectMode mode);
}