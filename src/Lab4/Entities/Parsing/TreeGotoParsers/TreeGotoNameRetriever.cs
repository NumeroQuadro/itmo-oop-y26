using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.GotoCommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.TreeGotoParsers;

public class TreeGotoNameRetriever : ITreeGoToParser
{
    private ITreeGoToParser? _nextParser;

    public ITreeGoToParser SetNext(ITreeGoToParser parser)
    {
        _nextParser = parser;

        return parser;
    }

    public ParsingResult Parse(GotoContextBuilder gotoContextRetriever, IEnumerable<string> args)
    {
        const string commandNameFirstPart = "tree";
        const string commandNameSecondPart = "goto";
        const int numberOfAttributeWords = 2;

        var listCommandLineArguments = new List<string>(args);
        if (listCommandLineArguments.Find(x => x == commandNameFirstPart) != commandNameFirstPart)
        {
            return new ParsingResult.FailureCurrentGoToNextParserWithMessage("first part of command name \"tree goto\" not found");
        }

        if (listCommandLineArguments.Find(x => x == commandNameSecondPart) != commandNameSecondPart)
        {
            return new ParsingResult.FailureCurrentGoToNextParserWithMessage("second part of command name \"tree goto\" not found");
        }

        IEnumerable<string> enumerable = listCommandLineArguments.Skip(numberOfAttributeWords);

        if (_nextParser is null)
        {
            return new ParsingResult.FailureCurrentGoToNextParserWithMessage("next parser for tree goto command is null");
        }

        return _nextParser.Parse(gotoContextRetriever, enumerable);
    }
}