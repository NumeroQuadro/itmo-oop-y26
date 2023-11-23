using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.ConnectCommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.ConnectCommandParsers;

public class ConnectCommandRequiredFlagRetriever : IConnectParser
{
    private IConnectParser? _nextParser;

    public IConnectParser SetNext(IConnectParser parser)
    {
        _nextParser = parser;

        return parser;
    }

    public ParsingResult Parse(ConnectContextBuilder connectContextRetriever, IEnumerable<string> args)
    {
        var enumerable = args.ToList();
        var argsList = enumerable.ToList();

        int firstIndexOptionalFlag = argsList.FindIndex(x => x == "-m");
        if (firstIndexOptionalFlag == -1)
        {
            return new ParsingResult.Failure("required flag not found");
        }

        const int indexOfRequiredFlag = 2;

        connectContextRetriever.WithConnectMode(argsList[indexOfRequiredFlag]);

        return new ParsingResult.Success();
    }
}