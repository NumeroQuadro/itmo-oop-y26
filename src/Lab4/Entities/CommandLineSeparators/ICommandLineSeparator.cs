using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandLineSeparators;

public interface ICommandLineSeparator
{
    public IEnumerable<string> Separate(string? args);
}