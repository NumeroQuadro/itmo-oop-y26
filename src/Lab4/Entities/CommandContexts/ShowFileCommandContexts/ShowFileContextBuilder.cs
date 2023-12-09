using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.ShowFileCommandContexts;

public class ShowFileContextBuilder : IContextBuilder
{
    private string _path = string.Empty;
    private ConnectMode _mode;

    public void WithPath(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            return;
        }

        _path = path;
    }

    public void WithConnectMode(string mode)
    {
        const string consoleModeString = "Console";

        if (mode == consoleModeString)
        {
            _mode = ConnectMode.Local;
        }
    }

    public CommandExecutionResult Build()
    {
        return new CommandExecutionResult.RetrievedSuccessfully(new ShowFileContext(_path, _mode));
    }
}