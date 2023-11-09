using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topics;

public interface IFilter
{
    public Message? PassThroughFilter(Message message);
}