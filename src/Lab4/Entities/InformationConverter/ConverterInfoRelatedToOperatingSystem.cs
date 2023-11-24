using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.AppStateInformation.AppStateInitial;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Directory;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.OutputReceivers;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.InformationConverter;

public class ConverterInfoRelatedToOperatingSystem : IConverterInfoRelatedToOperatingSystem
{
    private readonly FileSystemContext _fileSystemContext;

    public ConverterInfoRelatedToOperatingSystem(FileSystemContext fileSystemContext)
    {
        _fileSystemContext = fileSystemContext;
    }

    public IDirectory GetPathRelatedToSystem(string path)
    {
        return new WindowsDirectory(path);
    }

    public IOutputReceiver GetOutputReceiver(IEnumerable<CommandExecutionResult> results)
    {
        return new ConsoleOutputReceiver(results);
    }
}