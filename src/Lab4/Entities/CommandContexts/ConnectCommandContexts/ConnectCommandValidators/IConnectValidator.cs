using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.ConnectCommandContexts.ConnectCommandValidators;

public interface IConnectValidator
{
    public CommandContextValidationResult Validate(string path, ConnectMode mode);
}