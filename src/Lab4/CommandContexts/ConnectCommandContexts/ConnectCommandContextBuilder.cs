namespace Itmo.ObjectOrientedProgramming.Lab4;

public class ConnectCommandContextBuilder : IConnectCommandContextBuilder
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
            _mode = ConnectMode.Console;
        }
    }

    public ConnectCommandContext Build()
    {
        return new ConnectCommandContext(_path, _mode);
    }
}