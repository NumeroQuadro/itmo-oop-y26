using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Parsing.ConnectCommandParsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.ParserOrganizers;

public class ParserOrganizer : IParserOrganizer
{
    public CommandExecutionResult Retrieve(string[] args)
    {
        var connectCommandParser = new ConnectParser();
        var argsList = args.ToList();

        return connectCommandParser.Parse(argsList);
    }
}