using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.ConnectCommandParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.DeleteCommandParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.DisconnectCommandParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.FileCopyCommandParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.FileRenameCommandParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.FileShowCommandParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.MoveCommandParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.TreeGotoParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.TreeListCommandParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.ParserOrganizers;

public class ParserOrganizer : IParserOrganizer
{
    public CommandExecutionResult Retrieve(IEnumerable<string> args)
    {
        var connectCommandParser = new ConnectParser();
        connectCommandParser
            .SetNextParser(new TreeListParser())
            .SetNextParser(new TreeGotoParser())
            .SetNextParser(new FileShowParser())
            .SetNextParser(new MoveParser())
            .SetNextParser(new FileCopyParser())
            .SetNextParser(new DeleteParser())
            .SetNextParser(new FileRenameParser()
            .SetNextParser(new DisconnectParser()));
        var argsList = args.ToList();

        return connectCommandParser.Parse(argsList);
    }
}