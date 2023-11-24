using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.DeleteCommandContexts.DeleteCommandValidators;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.DeleteCommandContexts;

public class DeleteContextBuilder : IContextBuilder
{
    private string _path = string.Empty;

    public void WithPath(string path)
    {
        _path = path;
    }

    public CommandExecutionResult Build()
    {
        var validator = new DeleteValidator();
        CommandContextValidationResult commandContextValidationResult = validator.Validate(_path);

        if (commandContextValidationResult is CommandContextValidationResult.Failure failure)
        {
            return new CommandExecutionResult.RetrievedWithFailure(failure.FailureMessage);
        }

        return new CommandExecutionResult.RetrievedSuccessfully(new DeleteContext(_path));
    }
}