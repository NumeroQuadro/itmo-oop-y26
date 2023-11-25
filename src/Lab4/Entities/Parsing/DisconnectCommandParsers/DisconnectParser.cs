using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.DisconnectCommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.DisconnectCommandParsers;

public class DisconnectParser : ICommandParser
{
    private ICommandParser? _commandParser;

    public ICommandParser SetNextParser(ICommandParser parser)
    {
        _commandParser = parser;

        return parser;
    }

    public CommandExecutionResult Parse(IEnumerable<string> args)
    {
        var listCommandLineArguments = new List<string>(args);

        var nameRetriever = new DisconnectNameRetriever();
        var disconnectCommandContextBuilder = new DisconnectContextBuilder();

        ParsingResult parsingResult = nameRetriever.Parse(disconnectCommandContextBuilder, listCommandLineArguments);

        if (parsingResult is ParsingResult.Failure)
        {
            if (_commandParser is null)
            {
                return new CommandExecutionResult.RetrievedWithFailure("Next parser for disconnect command is null");
            }

            return _commandParser.Parse(listCommandLineArguments);
        }

        return disconnectCommandContextBuilder.Build();
    }
}