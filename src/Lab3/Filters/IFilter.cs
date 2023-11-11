using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Filters;

public interface IFilter
{
    public Message? PassThroughFilter(Message message);
}