using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.FileCopyCommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.FileCopyCommandParsers;

public class FileCopySecondRequiredArguemntRetriever : IFileCopyParser
{
    private IFileCopyParser? _nextParser;

    public IFileCopyParser SetNext(IFileCopyParser parser)
    {
        _nextParser = parser;

        return parser;
    }

    public ParsingResult Parse(FileCopyContextBuilder fileCopyContextBuilder, IEnumerable<string> args)
    {
        var enumerable = args.ToList();
        var argsList = enumerable.ToList();

        const int requiredArgumentsIndex = 1;

        fileCopyContextBuilder.WithDestinationPath(argsList[requiredArgumentsIndex]);

        return new ParsingResult.Success();
    }
}