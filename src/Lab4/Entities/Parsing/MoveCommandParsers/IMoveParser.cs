using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.MoveCommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.MoveCommandParsers;

public interface IMoveParser
{
    public IMoveParser SetNext(IMoveParser parser);
    public ParsingResult Parse(MoveContextBuilder moveContextBuilder, IEnumerable<string> args);
}