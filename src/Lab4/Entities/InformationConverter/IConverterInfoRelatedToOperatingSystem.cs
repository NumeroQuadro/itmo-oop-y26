using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Directory;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.OutputReceivers;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.InformationConverter;

public interface IConverterInfoRelatedToOperatingSystem
{
    public IDirectory GetPathRelatedToSystem(string path);
    public IOutputReceiver GetOutputReceiver(IEnumerable<CommandExecutionResult> results);
}