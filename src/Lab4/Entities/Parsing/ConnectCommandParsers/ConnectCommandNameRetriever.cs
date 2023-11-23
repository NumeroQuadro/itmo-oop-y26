using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.ConnectCommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsing.ConnectCommandParsers;

public class ConnectCommandNameRetriever : IConnectParser
{
    private IConnectParser? _nextParser;

    public IConnectParser SetNext(IConnectParser parser)
    {
        _nextParser = parser;

        return parser;
    }

    public ParsingResult Parse(ConnectCommandContextBuilder contextRetriever, IEnumerable<string> args)
    {
        const string commandName = "connect";
        const int numberOfRequiredArguments = 1;

        var listCommandLineArguments = new List<string>(args);
        if (listCommandLineArguments.Find(x => x == commandName) != commandName)
        {
            return new ParsingResult.Failure("name of command \"connect\" not found");
        }

        IEnumerable<string> enumerable = listCommandLineArguments.Skip(numberOfRequiredArguments);

        if (_nextParser is null)
        {
            return new ParsingResult.Failure("next parser is null");
        }

        return _nextParser.Parse(contextRetriever, enumerable);
    }
}