using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.DeleteCommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.DeleteCommandParsers;

public class DeleteParser : ICommandParser
{
    private ICommandParser? _nextParser;

    public ICommandParser SetNextParser(ICommandParser parser)
    {
        _nextParser = parser;

        return parser;
    }

    public CommandExecutionResult Parse(IEnumerable<string> args)
    {
        var listCommandLineArguments = new List<string>(args);

        var nameRetriever = new DeleteNameRetriever();
        nameRetriever.SetNext(new DeleteRequiredArgumentRetriever());

        var connectCommandContextBuilder = new DeleteContextBuilder();

        ParsingResult parsingResult = nameRetriever.Parse(connectCommandContextBuilder, listCommandLineArguments);

        if (parsingResult is ParsingResult.Failure)
        {
            if (_nextParser is null)
            {
                return new CommandExecutionResult.RetrievedWithFailure("Next parser for delete command is null");
            }

            return _nextParser.Parse(listCommandLineArguments);
        }

        return connectCommandContextBuilder.Build();
    }
}