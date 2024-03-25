using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.FileRenameContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.FileRenameCommandParsers;

public class FileRenameCommandNameRetriever : IFileRenameParser
{
    private IFileRenameParser? _nextParser;

    public IFileRenameParser SetNext(IFileRenameParser parser)
    {
        _nextParser = parser;

        return parser;
    }

    public ParsingResult Parse(FileRenameContextBuilder fileRenameContextBuilder, IEnumerable<string> args)
    {
        const string commandNameFirstPart = "file";
        const string commandNameSecondPart = "rename";
        const int numberOfAttributeWords = 2;

        var listCommandLineArguments = new List<string>(args);
        if (listCommandLineArguments.Find(x => x == commandNameFirstPart) != commandNameFirstPart)
        {
            return new ParsingResult.FailureCurrentGoToNextParserWithMessage("first part of command name \"file rename\" not found");
        }

        if (listCommandLineArguments.Find(x => x == commandNameSecondPart) != commandNameSecondPart)
        {
            return new ParsingResult.FailureCurrentGoToNextParserWithMessage("second part of command name \"file rename\" not found");
        }

        IEnumerable<string> enumerable = listCommandLineArguments.Skip(numberOfAttributeWords);

        if (_nextParser is null)
        {
            return new ParsingResult.FailureCurrentGoToNextParserWithMessage("next parser for file rename is null");
        }

        return _nextParser.Parse(fileRenameContextBuilder, enumerable);
    }
}