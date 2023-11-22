using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandParsers;

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
            return new ParsingResult.Failure();
        }

        var enumerable = args.ToList();
        var argsList = enumerable.ToList();

        const int requiredArgumentsIndex = 1; // path is only next to name, flags is in any order after path

        contextRetriever.WithPath(argsList[requiredArgumentsIndex]);

        return _nextParser.Parse(contextRetriever, argsList);
    }
}