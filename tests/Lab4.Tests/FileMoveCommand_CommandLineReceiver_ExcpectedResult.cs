using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandLineSeparators;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.MoveCommandParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class FileMoveCommand_CommandLineReceiver_ExcpectedResult
{
    [Theory]
    [InlineData("file move C:\\Users\\dimab\\Downloads C:\\Users\\dimab\\Downloads", ResultTypeForRetrieving.Success)]
    public void TestCase(string requestLine, ResultTypeForRetrieving resultType)
    {
        var connectCommandParser = new MoveParser();
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