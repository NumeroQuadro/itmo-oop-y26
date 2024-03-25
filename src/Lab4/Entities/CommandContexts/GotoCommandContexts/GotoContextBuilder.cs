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
        return new CommandExecutionResult.RetrievedSuccessfully(new GotoContext(_path));
    }
}