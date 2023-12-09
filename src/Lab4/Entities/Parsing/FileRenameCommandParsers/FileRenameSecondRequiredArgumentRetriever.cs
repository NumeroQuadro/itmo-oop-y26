using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.FileRenameContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.FileRenameCommandParsers;

public class FileRenameSecondRequiredArgumentRetriever : IFileRenameParser
{
    private IFileRenameParser? _nextParser;

    public IFileRenameParser SetNext(IFileRenameParser parser)
    {
        _nextParser = parser;

        return parser;
    }

    public ParsingResult Parse(FileRenameContextBuilder fileRenameContextBuilder, IEnumerable<string> args)
    {
        var enumerable = args.ToList();
        var argsList = enumerable.ToList();

        const int requiredArgumentsIndex = 1;

        fileRenameContextBuilder.WithName(argsList[requiredArgumentsIndex]);

        return new ParsingResult.Success();
    }
}