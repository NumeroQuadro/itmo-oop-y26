using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.FileRenameContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.FileRenameCommandParsers;

public class FileRenameFirstRequiredArgumentRetriever : IFileRenameParser
{
    private IFileRenameParser? _nextParser;

    public IFileRenameParser SetNext(IFileRenameParser parser)
    {
        _nextParser = parser;

        return parser;
    }

    public ParsingResult Parse(FileRenameContextBuilder fileRenameContextBuilder, IEnumerable<string> args)
    {
        if (_nextParser is null)
        {
            return new ParsingResult.CommandIncorrect("next parser for command file rename is null");
        }

        var enumerable = args.ToList();
        var argsList = enumerable.ToList();

        const int requiredArgumentsIndex = 0;

        fileRenameContextBuilder.WithPath(argsList[requiredArgumentsIndex]);

        return _nextParser.Parse(fileRenameContextBuilder, argsList);
    }
}