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
        return new CommandExecutionResult.RetrievedSuccessfully(new DeleteContext(_path));
    }
}