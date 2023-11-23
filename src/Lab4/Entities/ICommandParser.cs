using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities;

public interface ICommandParser
{
    public CommandExecutionResult Parse(IEnumerable<string> args);
    public ICommandParser SetNextParser(ICommandParser parser);
}