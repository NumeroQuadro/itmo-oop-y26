using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.FileCopyCommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.FileCopyCommandParsers;

public interface IFileCopyParser
{
    public IFileCopyParser SetNext(IFileCopyParser parser);
    public ParsingResult Parse(FileCopyContextBuilder fileCopyContextBuilder, IEnumerable<string> args);
}