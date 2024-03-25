namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public class MessageBuilder : IMessageBuilder
{
    private string _content = string.Empty;
    private int _importanceLevel;
    private string _body = string.Empty;

    public MessageBuilder SetUpContent(string content)
    {
        _content = content;
        return this;
    }

    public MessageBuilder SetUpImportanceLevel(int importanceLevel)
    {
        _importanceLevel = importanceLevel;
        return this;
    }

    public MessageBuilder SetUpBody(string body)
    {
        _body = body;
        return this;
    }

    public Message Build()
    {
        return new Message(_content, _importanceLevel, _body);
    }
}