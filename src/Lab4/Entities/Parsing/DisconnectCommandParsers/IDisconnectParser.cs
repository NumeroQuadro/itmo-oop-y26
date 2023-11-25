using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.DisconnectCommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.DisconnectCommandParsers;

public interface IDisconnectParser
{
    public IDisconnectParser SetNext(IDisconnectParser parser);
    public ParsingResult Parse(DisconnectContextBuilder disconnectCommandContextBuilder, IEnumerable<string> args);
}