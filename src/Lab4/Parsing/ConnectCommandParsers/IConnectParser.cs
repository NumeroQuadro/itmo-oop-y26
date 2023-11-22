using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandParsers;

public interface IConnectParser
{
    public IConnectParser SetNext(IConnectParser parser);
    public ParsingResult Parse(ConnectCommandContextBuilder contextRetriever, IEnumerable<string> args);
}