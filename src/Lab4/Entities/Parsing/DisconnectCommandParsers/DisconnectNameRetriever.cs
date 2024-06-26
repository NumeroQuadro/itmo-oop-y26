using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.DisconnectCommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.DisconnectCommandParsers;

public class DisconnectNameRetriever : IDisconnectParser
{
    private IDisconnectParser? _nextParser;

    public IDisconnectParser SetNext(IDisconnectParser parser)
    {
        _nextParser = parser;

        return parser;
    }

    public ParsingResult Parse(DisconnectContextBuilder disconnectCommandContextBuilder, IEnumerable<string> args)
    {
        const string commandName = "disconnect";
        const int numberOfNameArguments = 1;

        var listCommandLineArguments = new List<string>(args);
        if (listCommandLineArguments.Find(x => x == commandName) != commandName)
        {
            return new ParsingResult.FailureCurrentGoToNextParserWithMessage("name of command \"disconnect\" not found");
        }

        IEnumerable<string> lastCommandLineArguments = listCommandLineArguments.Skip(numberOfNameArguments);

        if (lastCommandLineArguments.Any())
        {
            return new ParsingResult.FailureCurrentGoToNextParserWithMessage("disconnect command cannot contain any words except \"disconnect\"");
        }

        return new ParsingResult.Success();
    }
}