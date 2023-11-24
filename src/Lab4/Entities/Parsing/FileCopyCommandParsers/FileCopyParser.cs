using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.FileCopyCommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.FileCopyCommandParsers;

public class FileCopyParser : ICommandParser
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

        var nameRetriever = new FileCopyNameRetriever();
        nameRetriever
            .SetNext(new FileCopyFirstRequiredArguemntRetriever())
            .SetNext(new FileCopySecondRequiredArguemntRetriever());

        var showFileCommandContextBuilder = new FileCopyContextBuilder();

        ParsingResult parsingResult = nameRetriever.Parse(showFileCommandContextBuilder, listCommandLineArguments);

        if (parsingResult is ParsingResult.Failure failure)
        {
            if (_nextParser is null)
            {
                return new CommandExecutionResult.RetrievedWithFailure($"Next parser for file copy command is null. {failure.FailureMessage}");
            }

            return _nextParser.Parse(listCommandLineArguments);
        }

        return showFileCommandContextBuilder.Build();
    }
}