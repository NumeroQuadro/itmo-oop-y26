using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.FileRenameContexts.FileRenameValidators;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.FileRenameContexts;

public class FileRenameContextBuilder : IContextBuilder
{
    private string _path = string.Empty;
    private string _name = string.Empty;

    public void WithPath(string path)
    {
        _path = path;
    }

    public void WithName(string name)
    {
        _name = name;
    }

    public CommandExecutionResult Build()
    {
        var validator = new FileRenameValidator();
        CommandContextValidationResult commandContextValidationResult = validator.Validate(_path, _name);

        if (commandContextValidationResult is CommandContextValidationResult.Failure failure)
        {
            return new CommandExecutionResult.RetrievedWithFailure(failure.FailureMessage);
        }

        return new CommandExecutionResult.RetrievedSuccessfully(new FileRenameContext(_path, _name));
    }
}