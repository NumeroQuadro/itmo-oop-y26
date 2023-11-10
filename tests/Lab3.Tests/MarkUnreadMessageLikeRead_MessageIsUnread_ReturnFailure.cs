using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Topics;
using Itmo.ObjectOrientedProgramming.Lab3.UserAdressees;
using Itmo.ObjectOrientedProgramming.Lab3.Users;
using Itmo.ObjectOrientedProgramming.Lab3.Users.MessageStates;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class MarkUnreadMessageLikeRead_MessageIsUnread_ReturnFailure
{
    [Fact]
    public void MarkUnreadMessage_ReturnFailre()
    {
        // Arrange
        const int importanceLevel = 5;
        var messageToSend = new Message("Hello, world!", importanceLevel);

        var topic = new Topic(new UserAdressee(), "numro finko", 5);
        MessageStatus? messageStatus = topic.RedirectMessage(messageToSend);

        Assert.NotNull(messageStatus);
        IMessageState result = messageStatus.MessageState.MoveToUnread();

        Assert.IsType<MessageErrorState>(result);
    }
}