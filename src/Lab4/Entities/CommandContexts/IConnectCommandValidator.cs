using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.ConnectCommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts;

public interface IConnectCommandValidator
{
    public CommandContextValidationResult Validate(string path, ConnectMode mode);
}