using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Topics;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class SendMessage_FilterDoNotSift_IfMessageDoNotCorrect
{
    [Fact]
    public void FilterMessage_ReturnNull()
    {
        // Arrange
        const int importanceLevel = 5;
        var messageToSend = new Message("Hello, world!", importanceLevel);
        IAdressee messangerAdresse = Substitute.For<IAdressee>();

        var topic = new Topic(messangerAdresse, "numero uno", 8);
        topic.RedirectMessage(messageToSend);

        // Act
        messangerAdresse.Received(0).GetMessage(messageToSend);
    }
}