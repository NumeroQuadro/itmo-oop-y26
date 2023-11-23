using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.ConnectCommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsing.ConnectCommandParsers;

public class ConnectCommandRequiredArgumentRetriever : IConnectParser
{
    private IConnectParser? _nextParser;
    public IConnectParser SetNext(IConnectParser parser)
    {
        _nextParser = parser;

        return parser;
    }

    public ParsingResult Parse(ConnectCommandContextBuilder contextRetriever, IEnumerable<string> args)
    {
        if (_nextParser is null)
        {
            return new ParsingResult.Failure("next parser is null");
        }

        var enumerable = args.ToList();
        var argsList = enumerable.ToList();

        const int requiredArgumentsIndex = 1; // path is only next to name, flags is in any order after path

        contextRetriever.WithPath(argsList[requiredArgumentsIndex]);

        return _nextParser.Parse(contextRetriever, argsList);
    }
}