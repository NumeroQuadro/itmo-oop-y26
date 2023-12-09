using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandLineSeparators;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.TreeGotoParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class TreeGotoCommand_CommandLineReceived_ExcpectedResult
{
    [Theory]
    [InlineData("tree goto C:\\Users\\dimab\\Downloads", ResultTypeForRetrieving.Success)]
    public void TestCase(string requestLine, ResultTypeForRetrieving resultType)
    {
        var connectCommandParser = new TreeGotoParser();
        var separator = new CommandLineSpaceSeparator();
        CommandExecutionResult result = connectCommandParser.Parse(separator.Separate(requestLine));

        if (resultType is ResultTypeForRetrieving.Success)
        {
            Assert.IsType<CommandExecutionResult.RetrievedSuccessfully>(result);
        }

        if (resultType is ResultTypeForRetrieving.Failure)
        {
            Assert.IsType<CommandExecutionResult.RetrievedWithFailure>(result);
        }
    }
}