using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.DeleteCommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.DeleteCommandParsers;

public interface IDeleteParser
{
    public IDeleteParser SetNext(IDeleteParser parser);
    public ParsingResult Parse(DeleteContextBuilder deleteContextBuilder, IEnumerable<string> args);
}