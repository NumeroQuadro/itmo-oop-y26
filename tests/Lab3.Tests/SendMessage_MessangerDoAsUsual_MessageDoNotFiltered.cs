using Itmo.ObjectOrientedProgramming.Lab3.Loggers;
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
        var messageToSend = new Message("Hello, world!", importanceLevel);
        MessangerAdresse messangerAdresse = Substitute.For<MessangerAdresse>(new Logger());

        var topic = new Topic(messangerAdresse, "numero uno", 5);
        topic.RedirectMessage(messageToSend);

        messangerAdresse.Received(1).GetMessage(messageToSend);
    }
}