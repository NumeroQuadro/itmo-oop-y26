using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.ConnectCommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.ConnectCommandParsers;

public class ConnectCommandRequiredArgumentRetriever : IConnectParser
{
    private IConnectParser? _nextParser;
    public IConnectParser SetNext(IConnectParser parser)
    {
        _nextParser = parser;

        return parser;
    }

    public ParsingResult Parse(ConnectContextBuilder connectContextRetriever, IEnumerable<string> args)
    {
        if (_nextParser is null)
        {
            return new ParsingResult.CommandIncorrect("next parser is null");
        }

        var enumerable = args.ToList();
        var argsList = enumerable.ToList();

        const int requiredArgumentsIndex = 0; // path is only next to name, flags is in any order after path

        try
        {
            connectContextRetriever.WithPath(argsList[requiredArgumentsIndex]);
        }
        catch (ArgumentOutOfRangeException e)
        {
            return new ParsingResult.CommandIncorrect($" connect command have to contain path argument {e.Message}");
        }

        return _nextParser.Parse(connectContextRetriever, argsList);
    }
}