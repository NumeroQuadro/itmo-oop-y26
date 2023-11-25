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
        return new CommandExecutionResult.RetrievedSuccessfully(new FileRenameContext(_path, _name));
    }
}