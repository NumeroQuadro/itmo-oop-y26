using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.DeleteCommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.DeleteCommandParsers;

public class DeleteRequiredArgumentRetriever : IDeleteParser
{
    private IDeleteParser? _nextParser;

    public IDeleteParser SetNext(IDeleteParser parser)
    {
        _nextParser = parser;

        return parser;
    }

    public ParsingResult Parse(DeleteContextBuilder deleteContextBuilder, IEnumerable<string> args)
    {
        var enumerable = args.ToList();
        var argsList = enumerable.ToList();

        const int requiredArgumentsIndex = 0;

        deleteContextBuilder.WithPath(argsList[requiredArgumentsIndex]);

        return new ParsingResult.Success();
    }
}