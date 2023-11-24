using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.ConnectCommandParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.TreeGotoParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.TreeListCommandParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.ParserOrganizers;

public class ParserOrganizer : IParserOrganizer
{
    public CommandExecutionResult Retrieve(string[] args)
    {
        var connectCommandParser = new ConnectParser();
        connectCommandParser.SetNextParser(new TreeListParser()).SetNextParser(new TreeGotoParser());
        var argsList = args.ToList();

        return connectCommandParser.Parse(argsList);
    }
}