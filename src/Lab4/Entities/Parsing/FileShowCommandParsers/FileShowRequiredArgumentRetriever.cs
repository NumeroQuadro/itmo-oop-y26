using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.ShowFileCommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.FileShowCommandParsers;

public class FileShowRequiredArgumentRetriever : IFileShowParser
{
    private IFileShowParser? _nextParser;
    public IFileShowParser SetNext(IFileShowParser parser)
    {
        _nextParser = parser;

        return parser;
    }

    public ParsingResult Parse(ShowFileContextBuilder showFileContextBuilder, IEnumerable<string> args)
    {
        if (_nextParser is null)
        {
            return new ParsingResult.CommandIncorrect("flag is required for file show command");
        }

        var enumerable = args.ToList();
        var argsList = enumerable.ToList();

        const int requiredArgumentsIndex = 0;

        showFileContextBuilder.WithPath(argsList[requiredArgumentsIndex]);

        return _nextParser.Parse(showFileContextBuilder, argsList);
    }
}