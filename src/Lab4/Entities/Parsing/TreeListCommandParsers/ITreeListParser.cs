using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.TreeListContext;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.TreeListCommandParsers;

public interface ITreeListParser
{
    public ITreeListParser SetNext(ITreeListParser parser);
    public ParsingResult Parse(TreeListContextBuilder contextRetriever, IEnumerable<string> args);
}