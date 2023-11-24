using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.GotoCommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.TreeGotoParsers;

public class TreeGotoRequiredArgumentRetriever : ITreeGoToParser
{
    private ITreeGoToParser? _nextParser;

    public ITreeGoToParser SetNext(ITreeGoToParser parser)
    {
        _nextParser = parser;

        return parser;
    }

    public ParsingResult Parse(GotoContextBuilder gotoContextRetriever, IEnumerable<string> args)
    {
        var enumerable = args.ToList();
        var argsList = enumerable.ToList();

        const int requiredArgumentsIndex = 0; // path is only next to name, flags is in any order after path

        gotoContextRetriever.WithPath(argsList[requiredArgumentsIndex]);

        return new ParsingResult.Success();
    }
}