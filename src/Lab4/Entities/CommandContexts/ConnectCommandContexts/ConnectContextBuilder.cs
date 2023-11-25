using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.ConnectCommandContexts.ConnectCommandValidators;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.ConnectCommandContexts;

public class ConnectContextBuilder : IContextBuilder
{
    private string _path = string.Empty;
    private ConnectMode _mode;

    public void WithPath(string path)
    {
        _path = path;
    }

    public void WithConnectMode(string mode)
    {
        const string consoleModeString = "local";

        _mode = mode == consoleModeString ? ConnectMode.Local : ConnectMode.NotSet;
    }

    public CommandExecutionResult Build()
    {
        var validator = new ConnectValidator();
        CommandContextValidationResult commandContextValidationResult = validator.Validate(_path, _mode);

        if (commandContextValidationResult is CommandContextValidationResult.Failure failure)
        {
            return new CommandExecutionResult.RetrievedWithFailure(failure.FailureMessage);
        }

        return new CommandExecutionResult.RetrievedSuccessfully(new ConnectContext(_path, _mode));
    }
}