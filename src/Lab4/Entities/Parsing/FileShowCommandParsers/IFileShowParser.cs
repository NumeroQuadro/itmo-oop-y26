using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.ShowFileCommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.FileShowCommandParsers;

public interface IFileShowParser
{
    public IFileShowParser SetNext(IFileShowParser parser);
    public ParsingResult Parse(ShowFileContextBuilder showFileContextBuilder, IEnumerable<string> args);
}