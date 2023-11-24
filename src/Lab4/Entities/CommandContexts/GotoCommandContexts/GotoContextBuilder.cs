using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.GotoCommandContexts.GotoCommandValidators;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.GotoCommandContexts;

public class GotoContextBuilder : IContextBuilder
{
    private string _path = string.Empty;

    public void WithPath(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            return;
        }

        _path = path;
    }

    public CommandExecutionResult Build()
    {
        var validator = new GotoValidator();
        CommandContextValidationResult commandContextValidationResult = validator.Validate(_path);

        if (commandContextValidationResult is CommandContextValidationResult.Failure failure)
        {
            return new CommandExecutionResult.RetrievedWithFailure(failure.FailureMessage);
        }

        return new CommandExecutionResult.RetrievedSuccessfully(new GotoContext());
    }
}