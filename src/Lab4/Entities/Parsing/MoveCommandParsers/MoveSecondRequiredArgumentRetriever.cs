using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.MoveCommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.MoveCommandParsers;

public class MoveSecondRequiredArgumentRetriever : IMoveParser
{
    private IMoveParser? _nextParser;

    public IMoveParser SetNext(IMoveParser parser)
    {
        _nextParser = parser;

        return parser;
    }

    public ParsingResult Parse(MoveContextBuilder moveContextBuilder, IEnumerable<string> args)
    {
        var enumerable = args.ToList();
        var argsList = enumerable.ToList();

        const int requiredArgumentsIndex = 1;

        moveContextBuilder.WithDestinationPath(argsList[requiredArgumentsIndex]);

        return new ParsingResult.Success();
    }
}