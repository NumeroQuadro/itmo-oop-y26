using Itmo.ObjectOrientedProgramming.Lab3.Filters;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.MessangerAdressees;
using Itmo.ObjectOrientedProgramming.Lab3.Messangers;
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

        FilterAddressee filterAddressee = Substitute.For<FilterAddressee>(new MessangerAdresse(new Messanger()), 8);

        var topic = new Topic(filterAddressee, "numero uno");
        topic.RedirectMessage(messageToSend);

        // Act
        filterAddressee.Received(0).GetMessage(messageToSend);
    }
}