using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.DeleteCommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.DeleteCommandParsers;

public class DeleteNameRetriever : IDeleteParser
{
    private IDeleteParser? _nextParser;

    public IDeleteParser SetNext(IDeleteParser parser)
    {
        _nextParser = parser;

        return parser;
    }

    public ParsingResult Parse(DeleteContextBuilder deleteContextBuilder, IEnumerable<string> args)
    {
        const string commandNameFirstPart = "file";
        const string commandNameSecondPart = "delete";
        const int numberOfAttributeWords = 2;

        var listCommandLineArguments = new List<string>(args);
        if (listCommandLineArguments.Find(x => x == commandNameFirstPart) != commandNameFirstPart)
        {
            return new ParsingResult.FailureCurrentGoToNextParserWithMessage("first part of command name \"file delete\" not found");
        }

        if (listCommandLineArguments.Find(x => x == commandNameSecondPart) != commandNameSecondPart)
        {
            return new ParsingResult.FailureCurrentGoToNextParserWithMessage("second part of command name \"file delete\" not found");
        }

        try
        {
            IEnumerable<string> enumerable = listCommandLineArguments.Skip(numberOfAttributeWords);

            if (_nextParser is null)
            {
                return new ParsingResult.FailureCurrentGoToNextParserWithMessage("next parser for delete command is null");
            }

            return _nextParser.Parse(deleteContextBuilder, enumerable);
        }
        catch (System.ArgumentOutOfRangeException e)
        {
            return new ParsingResult.FailureCurrentGoToNextParserWithMessage($"delete command need path argument (error: {e.Message})");
        }
        catch (ArgumentNullException e)
        {
            return new ParsingResult.FailureCurrentGoToNextParserWithMessage($"delete command need path argument (error: {e.Message})");
        }
    }
}