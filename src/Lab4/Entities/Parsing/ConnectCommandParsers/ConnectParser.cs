using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.ConnectCommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsing.ConnectCommandParsers;

public class ConnectParser : ICommandParser
{
    private ICommandParser? _nextCommandParser;
    public CommandExecutionResult Parse(IEnumerable<string> args)
    {
        var listCommandLineArguments = new List<string>(args);

        var nameRetriever = new ConnectCommandNameRetriever();
        nameRetriever.SetNext(new ConnectCommandRequiredArgumentRetriever())
            .SetNext(new ConnectCommandRequiredFlagRetriever());

        var connectCommandContextBuilder = new ConnectCommandContextBuilder();

        nameRetriever.Parse(connectCommandContextBuilder, listCommandLineArguments);

        return connectCommandContextBuilder.Build();
    }

    public ICommandParser SetNextParser(ICommandParser parser)
    {
        _nextCommandParser = parser;

        return parser;
    }
}