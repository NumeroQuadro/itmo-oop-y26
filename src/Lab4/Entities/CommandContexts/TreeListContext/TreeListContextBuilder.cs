using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.ConnectCommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.TreeListContext.TreeListCommandValidators;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.TreeListContext;

public class TreeListContextBuilder : IContextBuilder
{
    private int _depth;

    public TreeListContextBuilder WithDepth(int depth)
    {
        if (depth == 0)
        {
            const int defaultDepth = 1;
            depth = defaultDepth;
        }

        _depth = depth;
        return this;
    }

    public CommandExecutionResult Build()
    {
        var validator = new TreeListValidator();
        CommandContextValidationResult commandContextValidationResult = validator.Validate(_depth);

        if (commandContextValidationResult is CommandContextValidationResult.Failure failure)
        {
            return new CommandExecutionResult.RetrievedWithFailure(failure.FailureMessage);
        }

        return new CommandExecutionResult.RetrievedSuccessfully(new TreeListContext(_depth));
    }
}