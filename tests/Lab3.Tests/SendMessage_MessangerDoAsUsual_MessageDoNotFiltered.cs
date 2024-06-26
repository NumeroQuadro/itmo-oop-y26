using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.MessangerAdressees;
using Itmo.ObjectOrientedProgramming.Lab3.Topics;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class SendMessage_MessangerDoAsUsual_MessageDoNotFiltered
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

        MockableMessanger messanger = Substitute.For<MockableMessanger>();
        var messangerAdresse = new MessangerAdresse(messanger);

        var topic = new Topic(messangerAdresse, "numero uno");
        topic.RedirectMessage(messageToSend);

        messanger.Received(1).ReceiveMessage(messageToSend.Content);

        Assert.Equal(messanger.Messages.First(), messageToSend.Content);
    }
}