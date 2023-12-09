using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandLineSeparators;

public class CommandLineSpaceSeparator : ICommandLineSeparator
{
    public IEnumerable<string> Separate(string? args)
    {
        if (args is null)
        {
            return (IEnumerable<string>)System.Array.Empty<object>();
        }

        return args.Split(' ');
    }
}