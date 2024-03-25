using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.FileCopyCommandContexts;

public class FileCopyContextBuilder : IContextBuilder
{
    private string _sourcePath = string.Empty;
    private string _destinationPath = string.Empty;

    public FileCopyContextBuilder WithSourcePath(string sourcePath)
    {
        _sourcePath = sourcePath;
        return this;
    }

    public FileCopyContextBuilder WithDestinationPath(string destinationPath)
    {
        _destinationPath = destinationPath;
        return this;
    }

    public CommandExecutionResult Build()
    {
        return new CommandExecutionResult.RetrievedSuccessfully(new FileCopyContext(_sourcePath, _destinationPath));
    }
}