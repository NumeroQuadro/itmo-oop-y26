namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.AppStateInformation.AppStateInitial;

public class AppStateInitializer
{
    private readonly AppContext _appState;

    public AppStateInitializer(AppContext appState)
    {
        _appState = appState;
    }
}