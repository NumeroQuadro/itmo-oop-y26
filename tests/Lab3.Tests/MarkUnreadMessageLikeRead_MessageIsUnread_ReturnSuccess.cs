using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Topics;
using Itmo.ObjectOrientedProgramming.Lab3.UserAdressees;
using Itmo.ObjectOrientedProgramming.Lab3.Users;
using Itmo.ObjectOrientedProgramming.Lab3.Users.MessageStates;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class MarkUnreadMessageLikeRead_MessageIsUnread_ReturnSuccess
{
    [Fact]
    public void MarkUnreadMessage_ReturnFailre()
    {
        const int importanceLevel = 5;
        var builder = new MessageBuilder();
        builder
            .SetUpImportanceLevel(importanceLevel)
            .SetUpBody("numero uno goofy ahh cat")
            .SetUpContent("Hello, world!");
        Message messageToSend = builder.Build();
        var user = new User();
        var topic = new Topic(new UserAdressee(user), "numero uno");
        topic.RedirectMessage(messageToSend);

        IMessageState result = user.MarkMessageRead(messageToSend);

        Assert.IsType<MessageRead>(result);
    }
}