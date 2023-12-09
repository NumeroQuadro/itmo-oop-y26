using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.MoveCommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.MoveCommandParsers;

public class MoveParser : ICommandParser
{
    private ICommandParser? _nextParser;

    public ICommandParser SetNextParser(ICommandParser parser)
    {
        _nextParser = parser;

        return parser;
    }

    public CommandExecutionResult Parse(IEnumerable<string> args)
    {
        var listCommandLineArguments = new List<string>(args);

        var nameRetriever = new MoveNameRetriever();
        nameRetriever
            .SetNext(new MoveFirstRequiredArgumentRetriever())
            .SetNext(new MoveSecondRequiredArgumentRetriever());

        var showFileCommandContextBuilder = new MoveContextBuilder();

        ParsingResult parsingResult = nameRetriever.Parse(showFileCommandContextBuilder, listCommandLineArguments);

        if (parsingResult is ParsingResult.FailureCurrentGoToNextParserWithMessage failure)
        {
            if (_nextParser is null)
            {
                return new CommandExecutionResult.RetrievedWithFailure($"Next parser for file move command is null. {failure.FailureMessage}");
            }

            return _nextParser.Parse(listCommandLineArguments);
        }

        if (parsingResult is ParsingResult.CommandIncorrect incorrect)
        {
            return new CommandExecutionResult.RetrievedWithFailure(incorrect.FailureMessage);
        }

        return showFileCommandContextBuilder.Build();
    }
}