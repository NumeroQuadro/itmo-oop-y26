using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.ParserOrganizers;

public interface IParserOrganizer
{
    public CommandExecutionResult Retrieve(string[] args);
}