using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public interface ICommandParser
{
    public ParsingResult Parse(IEnumerable<string> args);
}