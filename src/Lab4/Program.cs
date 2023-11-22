using Itmo.ObjectOrientedProgramming.Lab4.CommandParsers;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public static class Program
{
    public static void Main(string[] args)
    {
        var parser = new ConnectParser();
        parser.Parse(args);
    }
}