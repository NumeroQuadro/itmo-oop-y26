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

        if (parsingResult is ParsingResult.FailureCurrentGoToNextParserWithMessage)
        {
            if (_commandParser is null)
            {
                return new CommandExecutionResult.RetrievedWithFailure("All commands checked, no correct found");
            }

            return _commandParser.Parse(listCommandLineArguments);
        }

        if (parsingResult is ParsingResult.CommandIncorrect incorrect)
        {
            return new CommandExecutionResult.RetrievedWithFailure(incorrect.FailureMessage);
        }

        return disconnectCommandContextBuilder.Build();
    }
}