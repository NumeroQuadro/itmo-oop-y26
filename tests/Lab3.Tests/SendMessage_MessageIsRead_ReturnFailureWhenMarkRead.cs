using Itmo.ObjectOrientedProgramming.Lab3.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Topics;
using Itmo.ObjectOrientedProgramming.Lab3.UserAdressees;
using Itmo.ObjectOrientedProgramming.Lab3.Users;
using Itmo.ObjectOrientedProgramming.Lab3.Users.MessageStates;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class SendMessage_MessageIsRead_ReturnFailureWhenMarkRead
{
    [Fact]
    public void MarkUnreadMessage_ReturnFailre()
    {
        // Arrange
        const int importanceLevel = 5;
        var builder = new MessageBuilder();
        builder
            .SetUpImportanceLevel(importanceLevel)
            .SetUpBody("numero uno goofy ahh cat")
            .SetUpContent("Hello, world!");
        Message messageToSend = builder.Build();

        var topic = new Topic(new UserAdressee(new Logger()), "numro finko", 5);
        MessageStatus? messageStatus = topic.RedirectMessage(messageToSend);

        Assert.NotNull(messageStatus);
        IMessageState result = messageStatus.MessageState.MoveToRead().MoveToRead();

        Assert.IsType<MessageErrorState>(result);
    }
}