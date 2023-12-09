using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.GotoCommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.TreeGotoParsers;

public interface ITreeGoToParser
{
    public ITreeGoToParser SetNext(ITreeGoToParser parser);
    public ParsingResult Parse(GotoContextBuilder gotoContextRetriever, IEnumerable<string> args);
}