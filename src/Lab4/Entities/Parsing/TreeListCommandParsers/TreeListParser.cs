using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.TreeListContext;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.TreeListCommandParsers;

public class TreeListParser : ICommandParser
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

        var nameRetriever = new TreeListCommandNameRetriever();
        nameRetriever
            .SetNext(new TreeListCommandDepthRequiredFlagRetriever());

        var treeListCommandContextBuilder = new TreeListContextBuilder();

        ParsingResult parsingResult = nameRetriever.Parse(treeListCommandContextBuilder, listCommandLineArguments);

        if (parsingResult is ParsingResult.Failure)
        {
            if (_nextCommandParser is null)
            {
                return new CommandExecutionResult.RetrievedWithFailure("Next parser is null");
            }

            return _nextCommandParser.Parse(listCommandLineArguments);
        }

        return treeListCommandContextBuilder.Build();
    }
}