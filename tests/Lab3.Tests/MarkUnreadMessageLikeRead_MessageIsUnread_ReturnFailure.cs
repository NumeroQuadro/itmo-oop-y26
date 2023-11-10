using Itmo.ObjectOrientedProgramming.Lab3.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Topics;
using Itmo.ObjectOrientedProgramming.Lab3.UserAdressees;
using Itmo.ObjectOrientedProgramming.Lab3.Users;
using Itmo.ObjectOrientedProgramming.Lab3.Users.MessageStates;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class MarkUnreadMessageLikeRead_MessageIsUnread_ReturnFailure
{
    [Fact]
    public void MarkUnreadMessage_ReturnFailre()
    {
        const int importanceLevel = 5;
        var messageToSend = new Message("Hello, world!", importanceLevel);

        Topic topic = Substitute.For<Topic>(new UserAdressee(new Logger()), "numero uno", 1);
        MessageStatus? messageStatus = topic.RedirectMessage(messageToSend);

        Assert.NotNull(messageStatus);
        IMessageState result = messageStatus.MessageState.MoveToRead().MoveToRead();

        Assert.IsType<MessageErrorState>(result);
    }
}