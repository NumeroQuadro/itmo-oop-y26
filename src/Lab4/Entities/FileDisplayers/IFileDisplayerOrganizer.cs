namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileDisplayers;

public interface IFileDisplayerOrganizer
{
    public IFileDisplayer GetFileDisplayerDependingOnSystem();
}