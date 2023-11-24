using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.MoveCommandContexts.MoveCommandValidators;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.MoveCommandContexts;

public class MoveContextBuilder : IContextBuilder
{
    private string _sourcePath = string.Empty;
    private string _destinationPath = string.Empty;

    public MoveContextBuilder WithSourcePath(string sourcePath)
    {
        _sourcePath = sourcePath;
        return this;
    }

    public MoveContextBuilder WithDestinationPath(string destinationPath)
    {
        _destinationPath = destinationPath;
        return this;
    }

    public CommandExecutionResult Build()
    {
        var validator = new MoveValidator();
        CommandContextValidationResult commandContextValidationResult = validator.Validate(_sourcePath, _destinationPath);

        if (commandContextValidationResult is CommandContextValidationResult.Failure failure)
        {
            return new CommandExecutionResult.RetrievedWithFailure(failure.FailureMessage);
        }

        return new CommandExecutionResult.RetrievedSuccessfully(new MoveContext(_sourcePath, _destinationPath));
    }
}