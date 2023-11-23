using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Directory;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.OutputReceivers;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using AppContext = Itmo.ObjectOrientedProgramming.Lab4.Entities.AppStateInformation.AppStateInitial.AppContext;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.InformationConverter;

public class ConverterInfoRelatedToOperatingSystem : IConverterInfoRelatedToOperatingSystem
{
    private readonly AppContext _appContext;

    public ConverterInfoRelatedToOperatingSystem(AppContext appContext)
    {
        _appContext = appContext;
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