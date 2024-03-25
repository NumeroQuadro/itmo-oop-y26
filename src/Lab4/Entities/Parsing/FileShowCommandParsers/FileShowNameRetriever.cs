using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.ShowFileCommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.FileShowCommandParsers;

public class FileShowNameRetriever : IFileShowParser
{
    private IFileShowParser? _nextFileShowParser;

    public IFileShowParser SetNext(IFileShowParser parser)
    {
        _nextFileShowParser = parser;

        return parser;
    }

    public ParsingResult Parse(ShowFileContextBuilder showFileContextBuilder, IEnumerable<string> args)
    {
        const string commandNameFirstPart = "file";
        const string commandNameSecondPart = "show";
        const int numberOfAttributeWords = 2;

        var listCommandLineArguments = new List<string>(args);
        if (listCommandLineArguments.Find(x => x == commandNameFirstPart) != commandNameFirstPart)
        {
            return new ParsingResult.FailureCurrentGoToNextParserWithMessage("first part of command name \"file show\" not found");
        }

        if (listCommandLineArguments.Find(x => x == commandNameSecondPart) != commandNameSecondPart)
        {
            return new ParsingResult.FailureCurrentGoToNextParserWithMessage("second part of command name \"file show\" not found");
        }

        IEnumerable<string> enumerable = listCommandLineArguments.Skip(numberOfAttributeWords);

        if (_nextFileShowParser is null)
        {
            return new ParsingResult.FailureCurrentGoToNextParserWithMessage("next parser is null");
        }

        return _nextFileShowParser.Parse(showFileContextBuilder, enumerable);
    }
}