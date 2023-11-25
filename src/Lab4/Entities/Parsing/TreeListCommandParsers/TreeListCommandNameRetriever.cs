using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.TreeListContext;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.TreeListCommandParsers;

public class TreeListCommandNameRetriever : ITreeListParser
{
    private ITreeListParser? _nextParser;

    public ITreeListParser SetNext(ITreeListParser parser)
    {
        _nextParser = parser;

        return parser;
    }

    public ParsingResult Parse(TreeListContextBuilder contextRetriever, IEnumerable<string> args)
    {
        const string commandNameFirstPart = "tree";
        const string commandNameSecondPart = "list";
        const int numberOfAttributeWords = 2;

        var listCommandLineArguments = new List<string>(args);
        if (listCommandLineArguments.Find(x => x == commandNameFirstPart) != commandNameFirstPart)
        {
            return new ParsingResult.FailureCurrentGoToNextParserWithMessage("first part of command name \"tree list\" not found");
        }

        if (listCommandLineArguments.Find(x => x == commandNameSecondPart) != commandNameSecondPart)
        {
            return new ParsingResult.FailureCurrentGoToNextParserWithMessage("second part of command name \"tree list\" not found");
        }

        IEnumerable<string> enumerable = listCommandLineArguments.Skip(numberOfAttributeWords);

        if (_nextParser is null)
        {
            return new ParsingResult.FailureCurrentGoToNextParserWithMessage("next parser is null");
        }

        return _nextParser.Parse(contextRetriever, enumerable);
    }
}