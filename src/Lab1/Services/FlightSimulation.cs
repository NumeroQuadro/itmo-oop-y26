using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Pathway;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.SpaceMovement;
using Itmo.ObjectOrientedProgramming.Lab1.Services.ResultsHandler;

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