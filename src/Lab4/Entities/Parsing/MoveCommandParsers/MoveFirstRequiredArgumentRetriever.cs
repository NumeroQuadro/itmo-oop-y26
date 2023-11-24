using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.MoveCommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.MoveCommandParsers;

public class MoveFirstRequiredArgumentRetriever : IMoveParser
{
    private IMoveParser? _nextParser;

    public IMoveParser SetNext(IMoveParser parser)
    {
        _nextParser = parser;

        return parser;
    }

    public ParsingResult Parse(MoveContextBuilder moveContextBuilder, IEnumerable<string> args)
    {
        if (_nextParser is null)
        {
            return new ParsingResult.Failure("next parser for command file move is null");
        }

        var enumerable = args.ToList();
        var argsList = enumerable.ToList();

        const int requiredArgumentsIndex = 0;

        moveContextBuilder.WithSourcePath(argsList[requiredArgumentsIndex]);

        return _nextParser.Parse(moveContextBuilder, argsList);
    }
}