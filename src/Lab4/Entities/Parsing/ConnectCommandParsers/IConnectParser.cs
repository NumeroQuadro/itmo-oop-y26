using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.ConnectCommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.ConnectCommandParsers;

public interface IConnectParser
{
    public IConnectParser SetNext(IConnectParser parser);
    public ParsingResult Parse(ConnectCommandContextBuilder contextRetriever, IEnumerable<string> args);
}