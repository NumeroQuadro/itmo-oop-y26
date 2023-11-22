using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandParsers;

public class ConnectParser : ICommandParser
{
    public ParsingResult Parse(IEnumerable<string> args)
    {
        const string commandName = "connect";

        var listCommandLineArguments = new List<string>(args);
        if (listCommandLineArguments.Find(x => x == commandName) == commandName)
        {
            var requiredArgumentRetriever = new ConnectCommandRequiredArgumentRetriever();
            requiredArgumentRetriever.SetNext(new ConnectCommandOptionalFlagRetriever());

            return requiredArgumentRetriever.Parse(new ConnectCommandContextBuilder(), listCommandLineArguments);
        }

        return new ParsingResult.Failure();
    }
}