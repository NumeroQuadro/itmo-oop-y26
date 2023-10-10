using Itmo.ObjectOrientedProgramming.Lab1.Environment.Pathway;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.ResultsHandler;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class FlightSimulation
{
    private Route _route;
    private ISpaceShuttle _shuttle;

    public FlightSimulation(Route route, ISpaceShuttle shuttle)
    {
        _route = route;
        _shuttle = shuttle;
    }

    public TripResultInformation StartSimulation()
    {
        return _route.GoThroughAllSegmentsAndGetResultOfTrip(_shuttle);
    }
}