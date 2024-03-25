using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.FileCopyCommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.FileCopyCommandParsers;

public class FileCopyFirstRequiredArguemntRetriever : IFileCopyParser
{
    private IFileCopyParser? _nextParser;

    public IFileCopyParser SetNext(IFileCopyParser parser)
    {
        _nextParser = parser;

        return parser;
    }

    public ParsingResult Parse(FileCopyContextBuilder fileCopyContextBuilder, IEnumerable<string> args)
    {
        if (_nextParser is null)
        {
            return new ParsingResult.CommandIncorrect("next parser for command file move is null");
        }

        var enumerable = args.ToList();
        var argsList = enumerable.ToList();

        const int requiredArgumentsIndex = 0;

        fileCopyContextBuilder.WithSourcePath(argsList[requiredArgumentsIndex]);

        return _nextParser.Parse(fileCopyContextBuilder, argsList);
    }
}