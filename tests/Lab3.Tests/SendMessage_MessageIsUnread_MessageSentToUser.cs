using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Topics;
using Itmo.ObjectOrientedProgramming.Lab3.UserAdressees;
using Itmo.ObjectOrientedProgramming.Lab3.Users;
using Itmo.ObjectOrientedProgramming.Lab3.Users.MessageStates;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class SendMessage_MessageIsUnread_MessageSentToUser
{
    private readonly Message _messageToSend;

    public SendMessage_MessageIsUnread_MessageSentToUser()
    {
        const int importanceLevel = 5;

        var builder = new MessageBuilder();
        builder
            .SetUpImportanceLevel(importanceLevel)
            .SetUpBody("numero uno goofy ahh cat")
            .SetUpContent("Hello, world!");
        _messageToSend = builder.Build();
    }

    [Fact]
    public void SendMessage_CheckReadStatus()
    {
        // Arrange
        var user = new User();
        UserAdressee userAdressee = new(user);
        var topic = new Topic(userAdressee, "numero finko");

        // Act
        topic.RedirectMessage(_messageToSend);

        IEnumerable<MessageWithStatus> messages = user.Messages;
        MessageWithStatus message = messages.Last();

        // Assert
        Assert.IsType<MessageUnread>(message.MessageState);
    }
}