using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Topics;
using Itmo.ObjectOrientedProgramming.Lab3.UserAdressees;
using Itmo.ObjectOrientedProgramming.Lab3.Users.MessageStates;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class SendMessage_MessageIsUnread_MessageSentToUser
{
    private readonly Message _messageToSend;

    public SendMessage_MessageIsUnread_MessageSentToUser()
    {
        const int importanceLevel = 5;
        _messageToSend = new Message("Hello, world!", importanceLevel);
    }

    [Fact]
    public void SendMessage_CheckReadStatus()
    {
        // Arrange
        UserAdressee userAdressee = new();
        Topic topic = Substitute.For<Topic>(userAdressee, "numero finko", 5);

        // Act
        topic.RedirectMessage(_messageToSend);

        // Assert
        Assert.IsType<MessageUnread>(userAdressee.GetUserReceivedMessagesStatuses.Last().MessageState);
    }
}