using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandLineSeparators;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Parsing.FileCopyCommandParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class CopyCommand_CommandLineReceived_ExcpectedResult
{
    [Theory]
    [InlineData("file copy C:\\Users\\dimab\\Downloads\\test.txt C:\\Users\\dimab\\Downloads\\testik.txt", ResultTypeForRetrieving.Success)]
    public void TestCase(string requestLine, ResultTypeForRetrieving resultType)
    {
        var connectCommandParser = new FileCopyParser();
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