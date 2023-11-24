using Itmo.ObjectOrientedProgramming.Lab4.Entities.AppStateInformation.AppStateInitial;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileDisplayers;

public class FileDisplayersOrganizer : IFileDisplayerOrganizer
{
    private FileSystemContext _context;

    public FileDisplayersOrganizer(FileSystemContext context)
    {
        _context = context;
    }

    public IFileDisplayer GetFileDisplayerDependingOnSystem()
    {
        return new ConsoleFileDisplayer();
    }
}