using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.FileCopyCommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.FileCopyCommandParsers;

public class FileCopyNameRetriever : IFileCopyParser
{
    private IFileCopyParser? _nextParser;

    public IFileCopyParser SetNext(IFileCopyParser parser)
    {
        _nextParser = parser;

        return parser;
    }

    public ParsingResult Parse(FileCopyContextBuilder fileCopyContextBuilder, IEnumerable<string> args)
    {
        const string commandNameFirstPart = "file";
        const string commandNameSecondPart = "copy";
        const int numberOfAttributeWords = 2;

        var listCommandLineArguments = new List<string>(args);
        if (listCommandLineArguments.Find(x => x == commandNameFirstPart) != commandNameFirstPart)
        {
            return new ParsingResult.Failure("first part of command name \"file copy\" not found");
        }

        if (listCommandLineArguments.Find(x => x == commandNameSecondPart) != commandNameSecondPart)
        {
            return new ParsingResult.Failure("second part of command name \"file copy\" not found");
        }

        IEnumerable<string> enumerable = listCommandLineArguments.Skip(numberOfAttributeWords);

        if (_nextParser is null)
        {
            return new ParsingResult.Failure("next parser is null");
        }

        return _nextParser.Parse(fileCopyContextBuilder, enumerable);
    }
}