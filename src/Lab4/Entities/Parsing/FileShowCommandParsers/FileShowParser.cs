using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.ShowFileCommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.FileShowCommandParsers;

public class FileShowParser : ICommandParser
{
    private ICommandParser? _nextCommandParser;

    public ICommandParser SetNextParser(ICommandParser parser)
    {
        _nextCommandParser = parser;

        return parser;
    }

    public CommandExecutionResult Parse(IEnumerable<string> args)
    {
        var listCommandLineArguments = new List<string>(args);

        var nameRetriever = new FileShowNameRetriever();
        nameRetriever
            .SetNext(new FileShowRequiredArgumentRetriever())
            .SetNext(new FileShowOptionalFlagRetriever());

        var showFileCommandContextBuilder = new ShowFileContextBuilder();

        ParsingResult parsingResult = nameRetriever.Parse(showFileCommandContextBuilder, listCommandLineArguments);

        if (parsingResult is ParsingResult.Failure)
        {
            if (_nextCommandParser is null)
            {
                return new CommandExecutionResult.RetrievedWithFailure("Next parser for file show command is null");
            }

            return _nextCommandParser.Parse(listCommandLineArguments);
        }

        return showFileCommandContextBuilder.Build();
    }
}