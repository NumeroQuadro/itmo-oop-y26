namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileDisplayers;

public class FileDisplayersOrganizer : IFileDisplayerOrganizer
{
    private ApplicationContext _context;

    public FileDisplayersOrganizer(ApplicationContext context)
    {
        _context = context;
    }

    public IFileDisplayer GetFileDisplayerDependingOnSystem()
    {
        return new ConsoleFileDisplayer();
    }
}