using Itmo.ObjectOrientedProgramming.Lab3.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.MessangerAdressees;
using Itmo.ObjectOrientedProgramming.Lab3.Topics;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class SendMessage_LoggerWasCalledOnce_IfMessageWasReceived
{
    private readonly Message _messageToSend;

    public SendMessage_LoggerWasCalledOnce_IfMessageWasReceived()
    {
        const int importanceLevel = 5;
        _messageToSend = new Message("Hello, world!", importanceLevel);
    }

    [Fact]
    public void FilterMessage_ReturnNull()
    {
        // Arrange
        Logger logger = Substitute.For<Logger>();
        var topic = new Topic(new MessangerAdresse(logger), "numero uno", 1);

        // Act
        topic.RedirectMessage(_messageToSend);

        // Assert
        logger.Received(1).LogEvent(_messageToSend.Content);
    }
}