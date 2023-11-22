using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandParsers;

public class ConnectCommandOptionalFlagRetriever : IConnectParser
{
    private IConnectParser? _nextParser;

    public IConnectParser SetNext(IConnectParser parser)
    {
        _nextParser = parser;

        return parser;
    }

    public ParsingResult Parse(ConnectCommandContextBuilder contextRetriever, IEnumerable<string> args)
    {
        var enumerable = args.ToList();
        var argsList = enumerable.ToList();

        int firstIndexOptionalFlag = argsList.FindIndex(x => x == "-m");
        if (firstIndexOptionalFlag == -1)
        {
            return new ParsingResult.Failure();
        }

        const int numberOfOptionalFlags = 1;

        argsList.GetRange(firstIndexOptionalFlag, numberOfOptionalFlags).ForEach(x => contextRetriever.WithConnectMode(x));

        return new ParsingResult.Success();
    }
}