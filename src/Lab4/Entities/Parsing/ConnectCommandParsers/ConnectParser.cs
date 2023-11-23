using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.ConnectCommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.ConnectCommandParsers;

public class ConnectParser : ICommandParser
{
    private ICommandParser? _nextCommandParser;
    public CommandExecutionResult Parse(IEnumerable<string> args)
    {
        var listCommandLineArguments = new List<string>(args);

        var nameRetriever = new ConnectCommandNameRetriever();
        nameRetriever
            .SetNext(new ConnectCommandRequiredArgumentRetriever())
            .SetNext(new ConnectCommandRequiredFlagRetriever());

        var connectCommandContextBuilder = new ConnectContextBuilder();

        nameRetriever.Parse(connectCommandContextBuilder, listCommandLineArguments);

        CommandExecutionResult s = connectCommandContextBuilder.Build();
        if (s is CommandExecutionResult.RetrievedWithFailure)
        {
            if (_nextCommandParser is null)
            {
                return new CommandExecutionResult.RetrievedWithFailure("Next parser is null");
            }

            return _nextCommandParser.Parse(listCommandLineArguments);
        }

        return connectCommandContextBuilder.Build();
    }

    public ICommandParser SetNextParser(ICommandParser parser)
    {
        _nextCommandParser = parser;

        return parser;
    }
}