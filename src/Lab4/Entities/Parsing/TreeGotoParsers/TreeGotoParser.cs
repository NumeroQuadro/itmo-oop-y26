using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.GotoCommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.TreeGotoParsers;

public class TreeGotoParser : ICommandParser
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

        var nameRetriever = new TreeGotoNameRetriever();
        nameRetriever.SetNext(new TreeGotoRequiredArgumentRetriever());

        var connectCommandContextBuilder = new GotoContextBuilder();

        ParsingResult parsingResult = nameRetriever.Parse(connectCommandContextBuilder, listCommandLineArguments);

        if (parsingResult is ParsingResult.Failure)
        {
            if (_nextCommandParser is null)
            {
                return new CommandExecutionResult.RetrievedWithFailure("Next parser is null");
            }

            return _nextCommandParser.Parse(listCommandLineArguments);
        }

        return connectCommandContextBuilder.Build();
    }
}