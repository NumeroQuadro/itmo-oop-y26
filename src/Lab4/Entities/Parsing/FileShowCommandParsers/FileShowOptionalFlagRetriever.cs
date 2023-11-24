using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.ShowFileCommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.FileShowCommandParsers;

public class FileShowOptionalFlagRetriever : IFileShowParser
{
    private IFileShowParser? _nextParser;

    public IFileShowParser SetNext(IFileShowParser parser)
    {
        _nextParser = parser;

        return parser;
    }

    public ParsingResult Parse(ShowFileContextBuilder showFileContextBuilder, IEnumerable<string> args)
    {
        var enumerable = args.ToList();
        var argsList = enumerable.ToList();

        int firstIndexOptionalFlag = argsList.FindIndex(x => x == "-m");
        if (firstIndexOptionalFlag != -1)
        {
            const int indexOfRequiredFlag = 2;

            showFileContextBuilder.WithConnectMode(argsList[indexOfRequiredFlag]);
        }

        return new ParsingResult.Success();
    }
}