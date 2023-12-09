using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.TreeListContext;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.TreeListCommandParsers;

public class TreeListCommandDepthRequiredFlagRetriever : ITreeListParser
{
    private ITreeListParser? _nextParser;

    public ITreeListParser SetNext(ITreeListParser parser)
    {
        _nextParser = parser;

        return parser;
    }

    public ParsingResult Parse(TreeListContextBuilder contextRetriever, IEnumerable<string> args)
    {
        var enumerable = args.ToList();
        var argsList = enumerable.ToList();

        const string flagName = "-d";

        int firstIndexOptionalFlag = argsList.FindIndex(x => x == flagName);
        if (firstIndexOptionalFlag != -1)
        {
            const int indexOfRequiredFlag = 1;
            string requiredFlag = argsList[indexOfRequiredFlag];
            contextRetriever.WithDepth(int.Parse(requiredFlag, CultureInfo.InvariantCulture));
        }

        return new ParsingResult.Success();
    }
}