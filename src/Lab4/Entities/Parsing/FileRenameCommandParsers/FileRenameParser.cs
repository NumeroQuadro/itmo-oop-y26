using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.FileRenameContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.FileRenameCommandParsers;

public class FileRenameParser : ICommandParser
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

        var nameRetriever = new FileRenameCommandNameRetriever();
        nameRetriever
            .SetNext(new FileRenameFirstRequiredArgumentRetriever())
            .SetNext(new FileRenameSecondRequiredArgumentRetriever());

        var connectCommandContextBuilder = new FileRenameContextBuilder();

        ParsingResult parsingResult = nameRetriever.Parse(connectCommandContextBuilder, listCommandLineArguments);

        if (parsingResult is ParsingResult.FailureCurrentGoToNextParserWithMessage)
        {
            if (_nextParser is null)
            {
                return new CommandExecutionResult.RetrievedWithFailure("Next parser for file rename command is null");
            }

            return _nextParser.Parse(listCommandLineArguments);
        }

        if (parsingResult is ParsingResult.CommandIncorrect incorrect)
        {
            return new CommandExecutionResult.ExecutedWithFailure(incorrect.FailureMessage);
        }

        return connectCommandContextBuilder.Build();
    }
}