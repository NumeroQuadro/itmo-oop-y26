namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.AppStateInformation.AppStateInitial;

public class AppStateInitializer
{
    private readonly FileSystemContext _fileSystemState;

    public AppStateInitializer(FileSystemContext fileSystemState)
    {
        _fileSystemState = fileSystemState;
    }
}