using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.ConnectCommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.ConnectCommandParsers;

public class ConnectCommandNameRetriever : IConnectParser
{
    private IConnectParser? _nextParser;

    public IConnectParser SetNext(IConnectParser parser)
    {
        _nextParser = parser;

        return parser;
    }

    public ParsingResult Parse(ConnectContextBuilder connectContextRetriever, IEnumerable<string> args)
    {
        const string commandName = "connect";
        const int numberOfAttributeWords = 1;

        var listCommandLineArguments = new List<string>(args);
        if (listCommandLineArguments.Find(x => x == commandName) != commandName)
        {
            return new ParsingResult.FailureCurrentGoToNextParserWithMessage("name of command \"connect\" not found");
        }

        try
        {
            IEnumerable<string> enumerable = listCommandLineArguments.Skip(numberOfAttributeWords);

            if (_nextParser is null)
            {
                return new ParsingResult.FailureCurrentGoToNextParserWithMessage("next parser for connect command is null");
            }

            return _nextParser.Parse(connectContextRetriever, enumerable);
        }
        catch (System.ArgumentOutOfRangeException e)
        {
            return new ParsingResult.FailureCurrentGoToNextParserWithMessage($"connect command need path argument (error: {e.Message})");
        }
        catch (ArgumentNullException e)
        {
            return new ParsingResult.FailureCurrentGoToNextParserWithMessage($"connect command need path argument (error: {e.Message})");
        }
    }
}