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
        var builder = new MessageBuilder();
        builder
            .SetUpImportanceLevel(importanceLevel)
            .SetUpBody("numero uno goofy ahh cat")
            .SetUpContent("Hello, world!");
        Message messageToSend = builder.Build();

        IAdressee messangerAdresse = Substitute.For<IAdressee>();

        var topic = new Topic(messangerAdresse, "numero uno", 8);
        topic.RedirectMessage(messageToSend);

        // Act
        messangerAdresse.Received(0).GetMessage(messageToSend);
    }
}