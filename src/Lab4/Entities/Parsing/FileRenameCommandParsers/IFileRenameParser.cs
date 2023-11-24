using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.FileRenameContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.FileRenameCommandParsers;

public interface IFileRenameParser
{
    public IFileRenameParser SetNext(IFileRenameParser parser);
    public ParsingResult Parse(FileRenameContextBuilder fileRenameContextBuilder, IEnumerable<string> args);
}