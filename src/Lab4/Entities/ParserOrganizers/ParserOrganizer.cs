using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.ConnectCommandParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

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